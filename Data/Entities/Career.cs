using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Base;

namespace Data.Entities
{
    public class Career : BaseEntity
    {
        [Required]
        public string Description { get; set; }
        
        // relaciones
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<CareerSubject> CareerSubjects { get; set; }
    }
}