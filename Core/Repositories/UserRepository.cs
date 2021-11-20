using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pocketBook.Core.Repository;
using pocketBook.Data;
using pocketBook.Models;

namespace pocketBook.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IuserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger logger) :
            base(context, logger)
        {
        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await dbset.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger
                    .LogError(ex,
                    "{Repo} All function error",
                    typeof (UserRepository));
                return new List<User>();
            }
        }

        public override async Task<bool> Upsert(User entity)
        {
            try
            {
                var existingUser =
                    await dbset
                        .Where(x => x.Id == entity.Id)
                        .FirstOrDefaultAsync();

                if (existingUser == null) return await Add(entity);

                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;
                return true;
            }
            catch (Exception ex)
            {
                _logger
                    .LogError(ex,
                    "{Repo} upsert function error",
                    typeof (UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist =
                    await dbset.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (exist == null) return false;

                dbset.Remove (exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger
                    .LogError(ex,
                    "{Repo} Delete function error",
                    typeof (UserRepository));
                return false;
            }
        }

        
    }
}
