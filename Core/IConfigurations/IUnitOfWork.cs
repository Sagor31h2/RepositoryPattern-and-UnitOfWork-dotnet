using System.Threading.Tasks;
using pocketBook.Core.Repository;

namespace pocketBook.Core.IConfigurations
{
    public interface IUnitOfWork
    {
        IuserRepository Users { get; }
        Task CompleteAsync();

    }
}