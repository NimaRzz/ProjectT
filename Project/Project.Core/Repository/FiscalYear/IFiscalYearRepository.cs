using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Common.Dto;
using Project.Core.Repository.BaseRepository;

namespace Project.Core.Repository.FiscalYear
{
    public interface IFiscalYearRepository : IBaseRepository
    {
        Task<ResultDto> IsExistsFiscalYearDate(DateTime StartDate, DateTime EndDate);
      
        Task<ResultDto> IsExistsFiscalYearStartDate(DateTime StartDate);
     
        Task<ResultDto> IsExistsFiscalYearEndDate(DateTime EndDate);

        Task<ResultDto> IsExistsFiscalYearName(string Name);
    }
}
