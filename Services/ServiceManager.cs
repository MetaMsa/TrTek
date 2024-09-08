using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IEventsService _eventsService;
        private readonly IUsersService _usersService;

        public ServiceManager(IEventsService eventsService, IUsersService usersService)
        {
            _eventsService = eventsService;
            _usersService = usersService;
        }

        public IEventsService EventsService => _eventsService;
        public IUsersService UsersService => _usersService;
    }
}