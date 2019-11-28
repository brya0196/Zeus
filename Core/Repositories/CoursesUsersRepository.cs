using System;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class CoursesUsersRepository : BaseRepository<CoursesUsers>, ICoursesUsersRepository
    {
        public CoursesUsersRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(CoursesUsers coursesUsers)
        {
            var coursesUsersToUpdate = await Get(coursesUsers.Id);

            coursesUsersToUpdate.User = coursesUsers.User;
            coursesUsersToUpdate.Subject = coursesUsers.Subject;
            coursesUsersToUpdate.Status = coursesUsers.Status;
            coursesUsers.updated_at = DateTime.Now;

            _context.CoursesUsers.Add(coursesUsers);
            await _context.SaveChangesAsync();
        }
    }
}