using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Base;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class User : BaseEntity
    {
        public string Matricula { get; set; }
        [Required, MinLength(6)]
        public string Password  { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        [Required, StringLength(12)]
        public string Cedula { get; set; }
        [Required, StringLength(20)]
        public string Phone { get; set; }    
        [Required, EmailAddress]
        public string Email { get; set; }
        
        // relaciones
        [ForeignKey("Gender"), Required]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        
        [ForeignKey("UserType"), Required]
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
        
        [ForeignKey("Career"), Required]
        public int CareerId { get; set; }
        public Career Career { get; set; }
        
        public IEnumerable<CoursesUsers> CoursesUsers { get; set; }

        public User WithoutPassword(User user)
        {
            user.Password = null;
            return user;
        }
    }
}