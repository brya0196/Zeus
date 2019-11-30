using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class AuthenticationDTO
    {
        [Required]
        public string EmailOrMatricula { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}