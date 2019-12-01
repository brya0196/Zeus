using System.Collections.Generic;
using Data.Base;

namespace Data.Entities
{
    public class UserType : BaseEntity
    {
        public string Description { get; set; }
        
        // relaciones
        public IEnumerable<User> Users { get; set; }
    }
}