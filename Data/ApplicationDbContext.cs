using Microsoft.EntityFrameworkCore;
using pocketBook.Models;
namespace pocketBook.Data
{
    public class ApplicationDbContext : DbContext

    {
        public virtual DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}