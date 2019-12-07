using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface IPeriodRepository : IBaseRepository<Period>
    {
        Task Update(Period period);
    }
}