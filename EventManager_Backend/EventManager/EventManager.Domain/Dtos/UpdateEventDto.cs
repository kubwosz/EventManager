using System;


namespace EventManager.Domain.Dtos
{
    public class UpdateEventDto
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ParticipantNumber { get; set; }

        public string Description { get; set; }
    }
}
