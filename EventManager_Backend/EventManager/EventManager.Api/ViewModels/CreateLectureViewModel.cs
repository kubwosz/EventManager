using System;

namespace EventManager.Api.ViewModels
{
    public class CreateLectureViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int EventId { get; set; }

        public int ParticipantNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
