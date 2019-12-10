using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Base;

namespace Data.Entities
{
    public class Subscription : BaseEntity
    {
        [Required, ForeignKey(("User"))] 
        public int UserId { get; set; }
        public User User { get; set; }

        [Required, ForeignKey("Period")]
        public int PeriodId { get; set; }
        public Period Period { get; set; }

        public IEnumerable<SubscriptionSection> SubscriptionSections { get; set; }
    }
}

