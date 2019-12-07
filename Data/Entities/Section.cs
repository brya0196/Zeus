using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Base;

namespace Data.Entities
{
    public class Section : BaseEntity
    {
        [Required]
        public string Days { get; set; }
        [Required]
        public int CurrentRoom { get; set; }
        [Required]
        public int MaximumRoom { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnds { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnds { get; set; }
        
        // relaciones
        [Required, ForeignKey("Course")] 
        public int CourseId { get; set; }
        public Course Course { get; set; }
        
        [Required, ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}