using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Core.Helpers;
using Core.Interfaces;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class PeriodRepository : BaseRepository<Period>, IPeriodRepository
    {
        public PeriodRepository(ZeusDbContext context) : base(context)
        {
        }

        public IEnumerable<Period> Pensum(int CareerId)
        {
            return _context.Periods
                .Include(p => p.CareerSubjects)
                .ThenInclude(cs => cs.Subject)
                .Where(p => p.CareerSubjects.Any(cs => cs.CareerId == CareerId));
        }

        public Period GetValidPeriod()
        {
            return _context.Periods.Last(x => x.Active == ValidityHelper.Yes);
        }

        public async Task Update(Period period)
        {
            var periodToUpdate = await Get(period.Id);

            periodToUpdate.Description = period.Description;
            periodToUpdate.Active = period.Active;
            periodToUpdate.UpdatedAt = DateTime.Now;

            _context.Periods.Update(periodToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}