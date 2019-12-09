using System.Collections.Generic;
using Data.Entities;

namespace Core.DTO
{
    public class AddSubscriptionDTO
    {
        public Subscription subscription;
        public List<SubscriptionSection> subscriptionSections;
    }
}