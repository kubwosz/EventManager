using System;

namespace EventManager.Api.ViewModels
{
    public class CreateEventViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ParticipantNumber { get; set; }

        public string Description { get; set; }
    }
}
