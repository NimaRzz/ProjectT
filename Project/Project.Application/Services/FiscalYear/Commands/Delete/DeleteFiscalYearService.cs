using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Interfaces.FiscalYear;
using Project.Domain.Common.Dto;
using Project.Domain.Repository.FiscalYear;
using FiscalYearModel = Project.Domain.Entities.FiscalYears.FiscalYear;

namespace Project.Application.Services.FiscalYear.Commands.Delete
{
    public class DeleteFiscalYearService : IDeleteFiscalYearService
    {
        private readonly IFiscalYearRepository _repository;
        public DeleteFiscalYearService(IFiscalYearRepository repository)
        {
            _repository = repository;
        }

       public async Task<ResultDto> Execute(long Id)
       {
          var fiscalYear = await _repository.Get<FiscalYearModel>(Id);

            await _repository.Delete<FiscalYearModel>(fiscalYear.Data);
            await _repository.SaveAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "حذف با موفقیت انجام شد"
            };
       }
    }
}
