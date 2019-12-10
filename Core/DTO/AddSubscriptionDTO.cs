using System.Collections.Generic;
using Data.Entities;

namespace Core.DTO
{
    public class AddSubscriptionDTO
    {
        public int UserId;
        public List<int> Sections;
    }
}