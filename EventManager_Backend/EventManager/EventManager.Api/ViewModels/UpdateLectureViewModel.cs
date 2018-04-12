using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Api.ViewModels
{
    public class UpdateLectureViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public int EventId { get; set; }

        public int ParticipantNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<LectureUserViewModel> LectureUsers { get; set; }

        public List<ReviewViewModel> Reviews { get; set; }
    }
}
