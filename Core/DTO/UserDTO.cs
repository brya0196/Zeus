using System.Runtime.Serialization;
using Data.Entities;

namespace Core.DTO
{
    public class UserDTO : User
    {
        public string Token { get; set; }

        public static UserDTO FromEntity(User user)
        {
            var dto = new UserDTO();
            dto.Name = user.Name;
            dto.Lastname = user.Lastname;
            dto.Matricula = user.Matricula;
            dto.Phone = user.Phone;
            dto.Cedula = user.Cedula;
            dto.Id = user.Id;
            dto.Gender = user.Gender;
            dto.Birthdate = user.Birthdate;
            dto.CreatedAt = user.CreatedAt;
            dto.UpdatedAt = user.UpdatedAt;
            dto.CareerId = user.CareerId;
            dto.UserTypeId = user.UserTypeId;
            dto.GenderId = user.GenderId;
            dto.Password = null;

            return dto;
        }
    }
}