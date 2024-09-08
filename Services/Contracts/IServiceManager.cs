using Entities.Dtos;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IEventsService EventsService { get; }   
        IUsersService UsersService { get; }
    }   
}