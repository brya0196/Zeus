using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface IStatusRepository : IBaseRepository<Status>
    {
        Task Update(Status status);
    }
}