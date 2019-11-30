using System;
using System.Collections.Generic;
using Data.Base;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class User : BaseEntity
    {
        public string Matricula { get; set; }
        public string Password  { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Cedula { get; set; }
        public string Phone { get; set; }    
        public string Email { get; set; }
        public string Token { get; set; }
        
        // relaciones
        public virtual Gender Gender { get; set; }
        public virtual UserType UserType { get; set; }
        
        public IEnumerable<CoursesUsers> CoursesUsers { get; set; }
    }
}