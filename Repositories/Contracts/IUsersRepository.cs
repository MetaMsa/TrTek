using Entities.Models;
using System.Linq;

namespace Repositories.Contracts
{
    public interface IUsersRepository : IRepositoryBase<Users>
    {
        IQueryable<Users> GetAllUsers(bool trackChanges);
        Users? GetUsersById(int userId, bool trackChanges);
        void CreateUser(Users user);
        void DeleteUser(Users user);
        void UpdateUser(Users user);
        Users? GetUserByEmail(string email, bool trackChanges);
        
    }
}