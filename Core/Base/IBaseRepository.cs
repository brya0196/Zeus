using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Base;

namespace Core.Base
{
    public interface IBaseRepository<T>
    {
        Task Add(T Entity);
        Task Delete(T Entity);
        IEnumerable<T> GetAll();
        T Get(int Id);
        Task Update(T Entity);
    }
}