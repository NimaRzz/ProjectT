using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Common.Dto;

namespace Project.Application.Common.Pagination
{
    public static class Pagination
    {
        public static ResultDto<IEnumerable<TSource>> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int totalPages)
        {
            if (source == null)
            {
                totalPages = 0;

                return new ResultDto<IEnumerable<TSource>>
                {
                    IsSuccess = false,
                    Message = "هیچ داده ای یافت نشد"
                };
            }

            int totalItems = source.Count();

            totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            if (totalPages < page || page == 0)
            {
                return new ResultDto<IEnumerable<TSource>>
                {
                    IsSuccess = false,
                    Message = "در این صحفه هیچ داده ای وجود ندارد"
                };
            }

           var data = source.Skip((page - 1) * pageSize).Take(pageSize);

            return new ResultDto<IEnumerable<TSource>>
            {
                Data = data,
                IsSuccess = true
            };
        }
    }
}
