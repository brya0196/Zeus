using System;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(Status status)
        {
            var statusToUpdate = await Get(status.Id);

            statusToUpdate.description = status.description;
            statusToUpdate.updated_at = DateTime.Now;

            _context.Statuses.Update(statusToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}