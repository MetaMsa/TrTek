using Entities.Models;

namespace Repositories.Contracts
{
    public interface IEventsRepository : IRepositoryBase<Event>
    {
        IQueryable<Event> GetAllEvents(bool trackChanges);
        Event? GetOneEvents(int id, bool trackChanges);
        void DeleteOneEvents(Event events);
    }
}