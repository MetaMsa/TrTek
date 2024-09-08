using Entities.Models;
using Services.Contracts;

namespace stajpro.Models
{
    public class EventListViewModel
    {
        public IEnumerable<Event> Events { get; set; } = Enumerable.Empty<Event>();
        public int TotalCount => Events.Count();
        private readonly IServiceManager _manager;

        public EventListViewModel(IServiceManager manager)
        {
            _manager = manager;

            var events = _manager.EventsService.GetAllEvents(false);
            Events = events;
        }
    }
}