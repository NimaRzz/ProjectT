using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Common.Dto;
using Project.Domain.Repository.FiscalYear;

namespace Project.Application.Common.Validation
{
    public class FiscalYearValidator
    {
         public static async Task<ResultDto> ValidateAddFiscalYearRequest(string Name, DateTime StartDate, DateTime EndDate, IFiscalYearRepository _repository)
        {
          
            if (string.IsNullOrEmpty(Name) || StartDate == null || EndDate == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "همه فیلد هارا تکمیل کنید"
                };
            }

            var isExistsFiscalYearName = await _repository.IsExistsFiscalYearName(Name);

            if (isExistsFiscalYearName.IsSuccess)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "این نام قبلا ثبت شده است"
                };
            }


            var isExistsFiscalYearDate = await _repository.IsExistsFiscalYearDate(StartDate, EndDate);

            if (isExistsFiscalYearDate.IsSuccess)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "هنگام وارد کردن تاریخ دقت بکنید تاریخ هایه شروع و پایانی که قصد اضافه کردن آن را دارید، نباید با تاریخ هایه شروع و پایان قبلی تداخلی داشته باشد و یا با انها یکسان باشد"
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public static async Task<ResultDto> ValidateDate(DateTime StartDate, DateTime EndDate)
        {
            if ( StartDate > EndDate)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "تاریخ شروع باید قبل از تاریخ پایان باشد"
                };
            }
            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
