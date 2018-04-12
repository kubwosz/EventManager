using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            Lectures = new List<LectureViewModel>();
            EventUsers = new List<EventUserViewModel>();
        }

        public int Id { get; set; }

        public int OwnerId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ParticipantNumber { get; set; }

        public string Description { get; set; }

        public List<LectureViewModel> Lectures { get; set; }

        public List<EventUserViewModel> EventUsers { get; set; }
    }
}
