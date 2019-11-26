using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ICoursesUsersRepository : IBaseRepository<CoursesUsers>
    {
        Task Update(CoursesUsers coursesUsers);
    }
}