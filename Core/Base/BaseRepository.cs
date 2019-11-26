using System.Collections.Generic;
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
            _context.Set<T>().Add(Entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            await _context.SaveChangesAsync();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToListAsync().Result;
        }

        public virtual T Get(int Id)
        {
            return _context.Set<T>().Find(Id);
        }
    }
}