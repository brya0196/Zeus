using System;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(Gender gender)
        {
            var genderToUpdate = await Get(gender.Id);

            genderToUpdate.description = gender.description;
            genderToUpdate.updated_at = DateTime.Now;

            _context.Genders.Update(genderToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}