using EventManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Domain.IServices
{
    public interface IEventService
    {
        EventDto CreateEvent(EventDto addEventDto);
        EventDto UpdateEvent(EventDto updateEventDto);
        List<EventDto> GetAll();
        EventDto GetOne(int id);
        bool DeleteEvent(int id);
    }
}
