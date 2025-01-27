using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Common.Dto;
using Project.Domain.Repository.BaseRepository;
using Project.Infrastructure.Contexts;

namespace Project.Infrastructure.Repositories.BaseRepository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly DataBaseContext _context;
        public BaseRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task Add<T>(T Object) where T : class
        {
            await _context.Set<T>().AddAsync(Object);
        }

        public async Task Delete<T>(T Object) where T : class
        {
            _context.Remove(Object);
        }

        public async Task Update<T>(T Object) where T : class
        {
            var entry = _context.Entry(Object);

            entry.CurrentValues.SetValues(Object);

            entry.State = EntityState.Modified;

            entry.Property("InsertTime").IsModified = false;

        }

        public async Task<ResultDto<T>> Get<T>(object Id) where T : class
        {
            T entity = null;

            if (Id is long longId)
            {
                entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(p => EF.Property<long>(p, "Id") == longId);
            }

            return new ResultDto<T>
            {
                Data = entity,
                IsSuccess = true
            };
        }

        public async Task<ResultDto<List<T>>> GetAll<T>() where T : class
        {
            var entity = await _context.Set<T>().AsNoTracking().ToListAsync();

            return new ResultDto<List<T>>
            {
                Data = entity
            };
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
