using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Services.FiscalYear.Queries.GetAll;
using Project.Domain.Common.Dto;

namespace Project.Application.Interfaces.FiscalYear
{
    public interface IGetAllFiscalYearService
    {
        Task<ResultDto<ResultGetAllFiscalYearDto>> Execute(RequestGetAllFiscalYearDto request);
    }

    public enum Ordering
    {
        IsRemoved = 0,
        IsActive = 1
    }
}
