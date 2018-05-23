using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Api.ViewModels
{
    public class CreateEventViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int ParticipantNumber { get; set; }

        public string Description { get; set; }
    }
}
