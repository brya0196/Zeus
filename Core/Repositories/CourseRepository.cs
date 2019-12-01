using System;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(Course course)
        {
            var courseToUpdate = await Get(course.Id);

            courseToUpdate.Description = course.Description;
            courseToUpdate.UpdatedAt = DateTime.Now;

            _context.Courses.Update(courseToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}