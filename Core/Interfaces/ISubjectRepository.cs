using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        Task Update(Subject subject);
    }
}