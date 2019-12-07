using System;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class PeriodRepository : BaseRepository<Period>, IPeriodRepository
    {
        public PeriodRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(Period period)
        {
            var periodToUpdate = await Get(period.Id);

            periodToUpdate.Description = period.Description;
            periodToUpdate.UpdatedAt = DateTime.Now;

            _context.Periods.Update(periodToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}