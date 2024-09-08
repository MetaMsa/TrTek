using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IEventsRepository _eventsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly ILinkLineRepository _linkLineRepository;

        public RepositoryManager(IEventsRepository eventsRepository, RepositoryContext context, IUsersRepository usersRepository, ILinkLineRepository linkLineRepository)
        {
            _context = context;
            _eventsRepository = eventsRepository;
            _usersRepository = usersRepository;
            _linkLineRepository = linkLineRepository;
        }

        public IEventsRepository Events => _eventsRepository;
        public IUsersRepository Users => _usersRepository;
        public ILinkLineRepository LinkLines => _linkLineRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}