using System;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class CareerRepository : BaseRepository<Career>, ICareerRepository
    {
        public CareerRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(Career career)
        {
            var careerToUpdate = await Get(career.Id);

            careerToUpdate.Description = career.Description;
            careerToUpdate.UpdatedAt = DateTime.Now;

            _context.Careers.Update(careerToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}