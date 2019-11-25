using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface IUserTypeRepository : IBaseRepository<UserType>
    {
        Task Update(UserType userType);
    }
}