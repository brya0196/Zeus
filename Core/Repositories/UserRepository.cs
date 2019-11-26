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

        public override Task Add(User Entity)
        {
            var lastUser = GetAll().Last();
            Entity.Matricula = MatriculaGenerator.Generator(lastUser.Matricula);
            return base.Add(Entity);
        }

        public async Task Update(User user)
        {
            var userToUpdate = Get(user.Id);

            userToUpdate.Name = user.Name;
            userToUpdate.Lastname = user.Lastname;
            userToUpdate.Email = user.Email;
            userToUpdate.Cedula = user.Cedula;
            userToUpdate.Phone = user.Phone;
            userToUpdate.Gender = user.Gender;
            userToUpdate.Birthdate = user.Birthdate;
            userToUpdate.updated_at = DateTime.Now;

            _context.Users.Add(userToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}