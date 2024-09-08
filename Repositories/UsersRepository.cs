using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq;

namespace Repositories
{
    public sealed class UsersRepository : RepositoryBase<Users>, IUsersRepository
    {
        public UsersRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateUser(Users user)
        {
            Create(user);
        }

        public void DeleteUser(Users user)
        {
            Remove(user);
        }
        
        public IQueryable<Users> GetAllUsers(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public Users? GetUsersById(int userId, bool trackChanges)
        {
            return FindByCondition(x => x.Id == userId, trackChanges);
        }

        public Users? GetUserByEmail(string email, bool trackChanges)
        {
            return FindByCondition(user => user.userEmail.Equals(email), trackChanges);
        }

        public void UpdateUser(Users user)
        {
            Update(user);
        }
    }
}