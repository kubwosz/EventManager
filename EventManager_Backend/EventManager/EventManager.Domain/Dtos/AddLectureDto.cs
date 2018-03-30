using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManager.Domain.Dtos
{
    public class AddLectureDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int EventId { get; set; }

        public int ParticipantNumber { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}