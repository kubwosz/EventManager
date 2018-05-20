using EventManager.Domain.Dtos;
using System.Collections.Generic;


namespace EventManager.Domain.IServices
{
    public interface IEventService
    {
        EventDto CreateEvent(EventDto addEventDto);
        EventDto UpdateEvent(EventDto updateEventDto);
        List<EventDto> GetAll();
        EventDto GetEventById(int id);
        bool DeleteEvent(int id);
    }
}
