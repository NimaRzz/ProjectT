﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Common.DateConverter;
using Project.Application.Common.Pagination;
using Project.Application.Interfaces.FiscalYear;
using Project.Domain.Common.Dto;
using Project.Domain.Repository.FiscalYear;
using FiscalYearModel = Project.Domain.Entities.FiscalYears.FiscalYear;

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

            var fiscalYearQuery = getAllFiscalYear.Data.AsQueryable();

            switch (request.ordering)
            {
                case Ordering.MostRecent:
                     fiscalYearQuery = fiscalYearQuery.OrderByDescending(p => p.StartDate).AsQueryable();
                    break;

                case Ordering.Name:
                     fiscalYearQuery = fiscalYearQuery.OrderBy(p => p.Name).AsQueryable();
                    break;

                default:
                    fiscalYearQuery = fiscalYearQuery.OrderByDescending(p => p.StartDate).AsQueryable();
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
                EndDate = ConvertDate.ConvertGregorianToPersian(p.EndDate)
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
