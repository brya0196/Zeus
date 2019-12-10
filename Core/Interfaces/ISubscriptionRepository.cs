using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ISubscriptionRepository : IBaseRepository<Subscription>
    {
        Task Update(Subscription subscription);
        Subscription GetCurrentSubscription(int UserId, int PeriodId);
    }
}