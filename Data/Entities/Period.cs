using System.Collections.Generic;
using Data.Base;

namespace Data.Entities
{
    public class Period : BaseEntity
    {
        public string Description { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }
    }
}