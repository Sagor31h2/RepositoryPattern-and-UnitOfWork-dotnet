using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using pocketBook.Core.IConfigurations;
using pocketBook.Core.Repositories;
using pocketBook.Core.Repository;

namespace pocketBook.Data
{
    //Idispoable is used for dispose the garbage collector
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger _logger;

        public IuserRepository Users { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        // disposing the garbage
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
