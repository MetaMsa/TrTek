using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class UsersManager : IUsersService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UsersManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateUser(Users user)
        {
            var userEntity = _mapper.Map<Users>(user);
            _repository.Users.CreateUser(userEntity);
            _repository.Save();
        }

        public void DeleteUser(Users user)
        {
            _repository.Users.DeleteUser(user);
            _repository.Save();
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _repository.Users.GetAllUsers(trackChanges: false);
        }

        public Users? GetUserById(int userId)
        {
            return _repository.Users.GetUsersById(userId, trackChanges: false);
        }

        public void UpdateUser(UserForUpdateDto user)
        {
            var userEntity = _mapper.Map<Users>(user);
            _repository.Users.UpdateUser(userEntity);
            _repository.Save();
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            return _repository.Users.GetUserByEmail(email, trackChanges: false);
        }

        public void RegisterUserToEvent(int userId, int eventId)
        {
            var user = _repository.Users.GetUsersById(userId, trackChanges: false);
            var eventEntity = _repository.Events.GetOneEvents(userId, trackChanges: false);

            if (user == null || eventEntity == null)
            {
                throw new Exception("User or Event not found.");
            }

            var userEvent = new LinkLine
            {
                UserId = userId,
                EventId = eventId,
                User = user,
                Event = eventEntity
            };

            _repository.LinkLines.Add(userEvent);
            _repository.Save();
        }
    }
}