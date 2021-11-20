using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pocketBook.Core.Repository;
using pocketBook.Data;

namespace pocketBook.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext context;
        protected DbSet<T> dbset;
        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext _context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbset.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbset.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbset.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}