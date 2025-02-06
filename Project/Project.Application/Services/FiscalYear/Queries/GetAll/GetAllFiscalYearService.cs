using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Common.DateConverter;
using Project.Application.Common.Pagination;
using Project.Application.Interfaces.FiscalYear;
using Project.Core.Common.Dto;
using Project.Core.Repository.FiscalYear;
using FiscalYearModel = Project.Core.Entities.FiscalYears.FiscalYear;

namespace Project.Application.Services.FiscalYear.Queries.GetAll
{
    public class GetAllFiscalYearService : IGetAllFiscalYearService
    {
            private readonly IFiscalYearRepository _repository;
        public GetAllFiscalYearService(IFiscalYearRepository repository)
        {

            _repository = repository;
        }

        public async Task<ResultDto<ResultGetAllFiscalYearDto>> Execute(RequestGetAllFiscalYearDto request)
        {
            var getAllFiscalYear = await _repository.GetAll<FiscalYearModel>();

           
            int totalPages = 0;

            var fiscalYearQuery = getAllFiscalYear.Data.OrderBy(p => p.StartDate).AsQueryable();

            switch (request.ordering)
            {
                case Ordering.IsRemoved:
                     fiscalYearQuery = fiscalYearQuery.Where(p => p.IsRemoved == true).AsQueryable();
                    break;

                case Ordering.IsActive:
                    fiscalYearQuery = fiscalYearQuery.Where(p => p.IsRemoved == false).AsQueryable();
                    break;

                default:
                    fiscalYearQuery = fiscalYearQuery.Where(p => p.IsRemoved == false).AsQueryable();
                    break;
            }


            var pagedResult = fiscalYearQuery.ToPaged(request.Page, request.PageSize, out totalPages);

            if (!string.IsNullOrEmpty(pagedResult.Message))
            {
                return new ResultDto<ResultGetAllFiscalYearDto>
                {
                    IsSuccess = true,
                    Message = pagedResult.Message,
                    Data = new ResultGetAllFiscalYearDto
                    {
                        TotalPages = totalPages,
                    }
                };
            }

           var fiscalYear = pagedResult.Data.Select(p => new GetAllFiscalYearDto
            {
                Id = p.Id,
                Name = p.Name,
                StartDate = ConvertDate.ConvertGregorianToPersian(p.StartDate),
                EndDate = ConvertDate.ConvertGregorianToPersian(p.EndDate),
                IsRemoved = p.IsRemoved
           }).ToList();

            return new ResultDto<ResultGetAllFiscalYearDto>
            {
                IsSuccess = true,
                Data = new ResultGetAllFiscalYearDto
                {
                    Items = fiscalYear,
                    TotalPages = totalPages,
                }
            };
        }
    }
}
