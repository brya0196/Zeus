using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task Update(User user);
        public Task ChangePassword(int Id, string password);
    }
}