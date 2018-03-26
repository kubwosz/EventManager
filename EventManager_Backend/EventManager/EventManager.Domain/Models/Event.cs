using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventManager.Domain.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        //public string OwnerName { get; set; }

        public int? OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual SimpleUser SimpleUser { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ParticipantNumber { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }

        public virtual ICollection<EventUser> EventUsers { get; set; }
    }
}
