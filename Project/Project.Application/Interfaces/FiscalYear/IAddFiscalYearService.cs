using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Services.FiscalYear.Commands.Add;
using Project.Domain.Common.Dto;


namespace Project.Application.Interfaces.FiscalYear
{
    public interface IAddFiscalYearService
    {
        Task<ResultDto> Execute(RequestAddFiscalYearDto request);
    }
}
