using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class CareerSubjectRepository : BaseRepository<CareerSubject>, ICareerSubjectRepository
    {
        public CareerSubjectRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(CareerSubject careerSubject)
        {
            var careerSubjectToUpdate = await Get(careerSubject.Id);

            careerSubjectToUpdate.Career = careerSubject.Career;
            careerSubjectToUpdate.Subject = careerSubject.Subject;

            _context.CareerSubjects.Add(careerSubjectToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}