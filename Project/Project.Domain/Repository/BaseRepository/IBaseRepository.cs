using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Common.Dto;

namespace Project.Domain.Repository.BaseRepository
{
    public interface IBaseRepository
    {
        Task Add<T>(T Object) where T : class;

        Task Delete<T>(T Object) where T : class;

        Task Update<T>(T Object) where T : class;

        Task<ResultDto<T>> Get<T>(object Id) where T : class;

        Task<ResultDto<List<T>>> GetAll<T>() where T : class;

        Task SaveAsync();
    }
}
