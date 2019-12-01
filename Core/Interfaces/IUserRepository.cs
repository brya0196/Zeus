using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task Update(User user);
        Task ChangePassword(int Id, string password);
    }
}