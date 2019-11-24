using System;

namespace Data.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}