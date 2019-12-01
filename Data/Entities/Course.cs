using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Base;

namespace Data.Entities
{
    public class Course : BaseEntity
    {
        [Required]
        public string Description { get; set; }
        
        public IEnumerable<Subject> Subjects { get; set; }
    }
}