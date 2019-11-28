using System.Threading;
using System.Threading.Tasks;

namespace Buglogger.Application.Interfaces
{
    public interface IAppDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}