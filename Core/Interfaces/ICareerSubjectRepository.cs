using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ICareerSubjectRepository : IBaseRepository<CareerSubject>
    {
        Task Update(CareerSubject careerSubject);
        IEnumerable<CareerSubject> GetAllWithRelations();
    }
}