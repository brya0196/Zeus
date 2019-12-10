using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Base;

namespace Data.Entities
{
    public class SubscriptionSection : BaseEntity
    {
        [Required, ForeignKey("Subscription")]
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        [Required, ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section Section { get; set; }
        
        [Required, ForeignKey("Status")] 
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}




