using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Common.Dto;
using Project.Domain.Repository.FiscalYear;
using Project.Infrastructure.Contexts;

namespace Project.Infrastructure.Repositories.FiscalYear
{
    public class FiscalYearRepository: BaseRepository.BaseRepository, IFiscalYearRepository
    {
        private readonly DataBaseContext _context;
        public FiscalYearRepository(DataBaseContext context):base(context)
        {
            _context = context;
        }

        public async Task<ResultDto> IsExistsFiscalYearDate(DateTime StartDate, DateTime EndDate)
        {
            var entity = await _context.FiscalYears.AsNoTracking().FirstOrDefaultAsync(p => p.StartDate == StartDate || p.EndDate == EndDate || ( p.StartDate < StartDate && p.EndDate > StartDate) || (p.StartDate < EndDate && p.EndDate > EndDate ));
       
            if (entity == null)
            {
                return new ResultDto
                {
                    IsSuccess = false
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };

        }


        public async Task<ResultDto> IsExistsFiscalYearStartDate(DateTime StartDate)
        {
            var entity = await _context.FiscalYears.AsNoTracking().FirstOrDefaultAsync(p => p.StartDate == StartDate || (p.StartDate < StartDate && p.EndDate > StartDate));

            if (entity == null)
            {
                return new ResultDto
                {
                    IsSuccess = false
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };

        }

        public async Task<ResultDto> IsExistsFiscalYearEndDate(DateTime EndDate)
        {
            var entity = await _context.FiscalYears.AsNoTracking().FirstOrDefaultAsync(p => p.EndDate == EndDate || (p.StartDate < EndDate && p.EndDate > EndDate));

            if (entity == null)
            {
                return new ResultDto
                {
                    IsSuccess = false
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };

        }

        public async Task<ResultDto> IsExistsFiscalYearName(string Name)
        {
            var entity = await _context.FiscalYears.AsNoTracking().FirstOrDefaultAsync(p => p.Name == Name);

            if (entity == null)
            {
                return new ResultDto
                {
                    IsSuccess = false
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    
    
    }
}
