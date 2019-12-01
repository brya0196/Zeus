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
        public DateTime DateStart { get; set; }
        public DateTime DateEnds { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnds { get; set; }
        [Required]
        public string Days { get; set; }
        [Required]
        public int CurrentRoom { get; set; }
        [Required]
        public int MaximumRoom { get; set; }
        
        
        // relaciones
        [Required, ForeignKey("Course")] 
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public IEnumerable<CareerSubject> CareerSubjects { get; set; }
    }
}