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

        public async Task<IEnumerable<T>> All()
        {
            return await dbset.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbset.FindAsync(id);
        }

        public async Task<bool> Add(T entity)
        {
            await dbset.AddAsync(entity);
            return true;
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}