using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ISectionRepository : IBaseRepository<Section>
    {
        Task Update(Section section);
    }
}