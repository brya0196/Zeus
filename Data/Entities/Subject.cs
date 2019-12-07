using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Base;

namespace Data.Entities
{
    public class Subject : BaseEntity
    {
        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string CodeRequirement { get; set; }

        // relaciones
        [Required, ForeignKey("Period")] 
        public int PeriodId { get; set; }

        public Period Period { get; set; }
        
        public IEnumerable<CareerSubject> CareerSubjects { get; set; }
        public IEnumerable<Section> Sections { get; set; }
    }
}