using System;
using System.Collections.Generic;

namespace EventManager.Domain.Dtos
{
    public class EventDto
    {
        public EventDto()
        {
            Lectures = new List<LectureDto>();
            EventUsers = new List<EventUserDto>();
        }

        public int Id { get; set; }
        
        public int OwnerId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ParticipantNumber { get; set; }

        public string Description { get; set; }

        public List<LectureDto> Lectures { get; set; }

        public List<EventUserDto> EventUsers { get; set; }
    }
}
