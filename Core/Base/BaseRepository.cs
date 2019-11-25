using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ZeusDbContext _context;

        public BaseRepository(ZeusDbContext context)
        {
            _context = context;
        }
        
        public async Task Add(T Entity)
        {
            _context.Set<T>().Add(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToListAsync().Result;
        }

        public T Get(int Id)
        {
            return _context.Set<T>().Find(Id);
        }
    }
}