using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Base;

namespace Data.Entities
{
    public class CareerSubject : BaseEntity
    {
        [Required, ForeignKey("Subject")] 
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Required, ForeignKey("Career")]
        public int CareerId { get; set; }
        public Career Career { get; set; }
    }
}