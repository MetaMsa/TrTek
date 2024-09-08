using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class EventsManager : IEventsService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public EventsManager(IRepositoryManager manager,
        IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void DeleteOneEvents(int id)
        {
            Entities.Models.Event events = GetOneEvents(id, false);
            if (events is not null)
            {
                _manager.Events.DeleteOneEvents(events);
                _manager.Save();
            }
        }

        public IEnumerable<Entities.Models.Event> GetAllEvents(bool trackChanges)
        {
            return _manager.Events.GetAllEvents(trackChanges);
        }

        public Entities.Models.Event? GetOneEvents(int id, bool trackChanges)
        {
            var events = _manager.Events.GetOneEvents(id, trackChanges);
            if (events is null)
                throw new Exception("Product not found!");
            return events;
        }
    }
}