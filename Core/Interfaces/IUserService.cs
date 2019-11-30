using Core.DTO;
using Data.Entities;

namespace Core.Interfaces
{
    public interface IUserService
    {
        User AddMatriculaToStudent(User user);
        User Authenticate(AuthenticationDTO model);
    }
}