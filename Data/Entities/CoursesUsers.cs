using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Base;

namespace Data.Entities
{
    public class CoursesUsers : BaseEntity
    {
        [Required, ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        
        [Required, ForeignKey("Status")] 
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}