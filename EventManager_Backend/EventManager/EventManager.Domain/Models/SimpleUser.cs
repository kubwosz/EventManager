using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManager.Domain.Models
{
    public class SimpleUser
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<LectureUser> LectureUsers { get; set; }

        public virtual ICollection<EventUser> EventUsers { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
