using System.Collections.Generic;
using Data.Base;

namespace Data.Entities
{
    public class Period : BaseEntity
    {
        public string Description { get; set; }
        public int Active { get; set; }

        public IEnumerable<CareerSubject> CareerSubjects { get; set; }
    }
}