using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Base;

namespace Data.Entities
{
    public class Status : BaseEntity
    {
        [Required]
        public string Description { get; set; }
        
        // relaciones
        public IEnumerable<SubscriptionSection> SubscriptionSections { get; set; }
    }
}