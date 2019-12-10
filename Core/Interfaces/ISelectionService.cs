using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ISelectionService
    {
        IEnumerable<Section> GetCurrentSelection(int UserId, int CareerId);
        Subscription GetCurrentSubscription(int UserId);
        void SubscribeStudent(AddSubscriptionDTO addSubscriptionDto);
        void DeleteSubscribeStudent(int subscriptionSectionId);
        List<Subscription> GetSubscriptions(int UserId);
        List<Subject> GetSubjects(int CareerId);
    }
}