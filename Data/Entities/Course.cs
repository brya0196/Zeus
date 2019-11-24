using System.Collections.Generic;
using Data.Base;

namespace Data.Entities
{
    public class Course : BaseEntity
    {
        public string description { get; set; }
        
        public IEnumerable<Subject> Subjects { get; set; }
    }
}