using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ICareerRepository : IBaseRepository<Career>
    {
        Task Update(Career career);
    }
}