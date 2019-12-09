using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ISelectionService
    {
        IEnumerable<Section> GetCurrentSelection(int UserId, int CareerId);
        Subscription GetCurrentSubscription(int UserId);
        Task AddSubscription(Subscription subscription, List<SubscriptionSection> subscriptionSections);
        List<Subscription> GetSubscriptions(int UserId);
        List<Subject> GetSubjects(int CareerId);
    }
}