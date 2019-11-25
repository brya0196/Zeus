using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface IGenderRepository : IBaseRepository<Gender>
    {
        Task Update(Gender gender);
    }
}