using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected ZeusDbContext _context;

        public BaseRepository(ZeusDbContext context)
        {
            _context = context;
        }
        
        public virtual async Task Add(T Entity)
        {
            Entity.created_at = DateTime.Now;
            _context.Set<T>().Add(Entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(int Id)
        {
            var entity = await Get(Id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return  _context.Set<T>().ToListAsync().Result;
        }

        public virtual async Task<T> Get(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }
    }
}