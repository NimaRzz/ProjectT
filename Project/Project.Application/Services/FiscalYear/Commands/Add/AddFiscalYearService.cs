using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Common.DateConverter;
using Project.Application.Common.Validation;
using Project.Application.Interfaces.FiscalYear;
using Project.Domain.Common.Dto;
using Project.Domain.Repository.FiscalYear;
using FiscalYearModel = Project.Domain.Entities.FiscalYears.FiscalYear;
namespace Project.Application.Services.FiscalYear.Commands.Add
{
    public class AddFiscalYearService : IAddFiscalYearService
    {
        private readonly IFiscalYearRepository _repository;
        public AddFiscalYearService(IFiscalYearRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Execute(RequestAddFiscalYearDto request)
        {

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

            var validateRequest = await FiscalYearValidator.ValidateAddFiscalYearRequest(request.Name, StartDate, EndDate, _repository);


            if (!validateRequest.IsSuccess)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = validateRequest.Message
                };
            }

            FiscalYearModel fiscalYear = new()
            {
                Name = request.Name,
                StartDate = StartDate,
                EndDate = EndDate
            };


           await _repository.Add<FiscalYearModel>(fiscalYear);
           await _repository.SaveAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "با موفقیت افزوده شد"
            };
        }
    }
}
