using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public sealed class EventsRepository : RepositoryBase<Event>, IEventsRepository
    {
        public EventsRepository(RepositoryContext context) : base(context)
        {

        }
        public void DeleteOneEvents(Event events) => Remove(events);

        public IQueryable<Event> GetAllEvents(bool trackChanges) => FindAll(trackChanges);

        public Event? GetOneEvents(int id, bool trackChanges)
        {
              return FindByCondition(p => p.Id.Equals(id),trackChanges);  
        }
    }
}