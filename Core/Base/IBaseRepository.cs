using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Base;

namespace Core.Base
{
    public interface IBaseRepository<T>
    {
        Task Add(T Entity);
        Task Delete(int Id);
        IEnumerable<T> GetAll();
        Task<T> Get(int Id);
    }
}