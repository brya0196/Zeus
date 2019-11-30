using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Core.Generators;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(User user)
        {
            var userToUpdate = await Get(user.Id);

            userToUpdate.Name = user.Name;
            userToUpdate.Lastname = user.Lastname;
            userToUpdate.Email = user.Email;
            userToUpdate.Cedula = user.Cedula;
            userToUpdate.Phone = user.Phone;
            userToUpdate.Gender = user.Gender;
            userToUpdate.Birthdate = user.Birthdate;
            userToUpdate.updated_at = DateTime.Now;

            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task ChangePassword(int Id, string password)
        {
            var userToUpdate = await Get(Id);

            userToUpdate.Password = password;

            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}