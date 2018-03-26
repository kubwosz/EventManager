using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventManager.Domain.Models
{
    public class EventUser
    {
        [Key]
        public int Id { get; set; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual SimpleUser SimpleUser { get; set; }
    }
}
