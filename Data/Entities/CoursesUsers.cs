using Data.Base;

namespace Data.Entities
{
    public class CoursesUsers : BaseEntity
    {
        public virtual Subject Subject { get; set; }
        public virtual User User { get; set; }
        public virtual Status Status { get; set; }
    }
}