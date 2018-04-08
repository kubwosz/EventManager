using EventManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Domain.IServices
{
    public interface IEventService
    {
        EventDto CreateEvent(CreateEventDto addEventDto);


        EventDto UpdateEvent(UpdateEventDto updateEventDto);


        List<EventDto> GetAll();


        bool DeleteEvent(int id);
    }
}
