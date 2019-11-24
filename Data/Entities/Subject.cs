using System;
using System.Collections.Generic;
using Data.Base;

namespace Data.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string CodeRequirement { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnds { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnds { get; set; }
        public string Days { get; set; }
        
        
        // relaciones
        public virtual Course Course { get; set; }
    }
}