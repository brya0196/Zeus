using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task Update(Course course);
    }
}