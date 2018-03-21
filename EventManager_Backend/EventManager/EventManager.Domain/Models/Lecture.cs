using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManager.Domain.Models
{
    public class Lecture
    {
        [Key]
        public int Id { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ParticipantNumber { get; set; }

        public string Description { get; set; }

        public virtual ICollection<LectureUser> LectureUsers { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
