using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IUsersService
    {
        IEnumerable<Users> GetAllUsers();
        Users? GetUserById(int userId);
        void CreateUser(Users user);
        void UpdateUser(UserForUpdateDto user);
        void DeleteUser(Users user);
        Task<Users> GetUserByEmail(string email);
    }
}