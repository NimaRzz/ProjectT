using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Services.FiscalYear.Commands.Update;
using Project.Core.Common.Dto;


namespace Project.Application.Interfaces.FiscalYear
{
    public interface IUpdateFiscalYearService
    {
        Task<ResultDto> Execute(RequestUpdateFiscalYearDto request);
    }
}
