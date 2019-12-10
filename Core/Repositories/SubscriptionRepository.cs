using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Core.Helpers;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(Subscription subscription)
        {
            var subscriptionToUpdate = await Get(subscription.Id);

            subscriptionToUpdate.PeriodId = subscription.PeriodId;
            subscriptionToUpdate.UserId = subscription.UserId;
            subscriptionToUpdate.UpdatedAt = DateTime.Now;

            _context.Subscriptions.Update(subscriptionToUpdate);
            await _context.SaveChangesAsync();
        }

        public Subscription GetCurrentSubscription(int UserId, int PeriodId)
        {
            return _context.Subscriptions.First(x => x.UserId == UserId && x.PeriodId == PeriodId && DatetimeHelper.IsFromCurrentYear(x.CreatedAt));
        }
    }
}