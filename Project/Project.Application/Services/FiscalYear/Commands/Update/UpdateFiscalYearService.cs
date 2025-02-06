using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Common.DateConverter;
using Project.Application.Common.Validation;
using Project.Application.Interfaces.FiscalYear;
using Project.Core.Common.Dto;
using Project.Core.Repository.FiscalYear;
using FiscalYearModel = Project.Core.Entities.FiscalYears.FiscalYear;


namespace Project.Application.Services.FiscalYear.Commands.Update
{
    public class UpdateFiscalYearService : IUpdateFiscalYearService
    {
        private readonly IFiscalYearRepository _repository;

        public UpdateFiscalYearService(IFiscalYearRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Execute(RequestUpdateFiscalYearDto request)
        {

            if (string.IsNullOrEmpty(request.Name) || request.StartDate == null || request.EndDate == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "همه فیلد هارا تکمیل کنید"
                };
            }

            var fiscalYear = await _repository.Get<FiscalYearModel>(request.Id);

            DateTime StartDate = ConvertDate.ConvertPersianToGregorian(request.StartDate);
            DateTime EndDate = ConvertDate.ConvertPersianToGregorian(request.EndDate);

           var validateDateResult = await FiscalYearValidator.ValidateDate(StartDate, EndDate);

            if (!validateDateResult.IsSuccess)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = validateDateResult.Message
                };
            }

            if (fiscalYear.Data.StartDate != request.StartDate && fiscalYear.Data.EndDate == request.EndDate)
            {

                var isExistsFiscalYearStartDate = await _repository.IsExistsFiscalYearStartDate(StartDate);

                if (isExistsFiscalYearStartDate.IsSuccess)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "تاریخ شروع با تاریخ شروع و پایان دیگری تداخل دارد و یا با تاریخ شروع دیگری برابر است"
                    };
                }
            }

            if (fiscalYear.Data.EndDate != request.EndDate && fiscalYear.Data.StartDate == request.StartDate)
            {
                var isExistsFiscalYearEndDate = await _repository.IsExistsFiscalYearEndDate(EndDate);

                if (isExistsFiscalYearEndDate.IsSuccess)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "تاریخ پایان با تاریخ شروع و پایان دیگری تداخل دارد و یا با تاریخ پایان دیگری برابر است"
                    };
                }
            }

            if (fiscalYear.Data.StartDate != request.StartDate && fiscalYear.Data.EndDate != request.EndDate)
            {
                var isExistsFiscalYearDate = await _repository.IsExistsFiscalYearDate(StartDate, EndDate);

                if (isExistsFiscalYearDate.IsSuccess)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "هنگام وارد کردن تاریخ دقت بکنید تاریخ هایه شروع و پایانی که قصد اضافه کردن آن را دارید، نباید با تاریخ هایه شروع و پایان قبلی تداخلی داشته باشد و یا با انها یکسان باشد"
                    };
                }
            }


            if (fiscalYear.Data.Name != request.Name)
            {
                
                var isExistsFiscalYearName = await _repository.IsExistsFiscalYearName(request.Name);

                if (isExistsFiscalYearName.IsSuccess)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "این نام قبلا ثبت شده است"
                    };
                }
                else
                {
                    fiscalYear.Data.Name = request.Name;
                }
            }

            fiscalYear.Data.StartDate = StartDate;
            fiscalYear.Data.EndDate = EndDate;

            await _repository.Update<FiscalYearModel>(fiscalYear.Data);
            await _repository.SaveAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "اپدیت با موفقیت انجام شد"
            };

        }
    }
}
