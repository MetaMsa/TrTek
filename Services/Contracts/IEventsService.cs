using Entities.Models;

namespace Services.Contracts
{
    public interface IEventsService
    {
        IEnumerable<Event> GetAllEvents(bool trackChanges);
        Event? GetOneEvents(int id, bool trackChanges);
        void DeleteOneEvents(int id);
    }
}