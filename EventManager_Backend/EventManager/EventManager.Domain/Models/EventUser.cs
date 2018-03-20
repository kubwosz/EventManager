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

        public virtual Event Event { get; set; }

        // Nazwa UserId
        public int SimpleUserId { get; set; }

        public virtual SimpleUser SimpleUser { get; set; }
    }
}
