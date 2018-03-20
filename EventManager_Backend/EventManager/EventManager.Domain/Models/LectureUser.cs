using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventManager.Domain.Models
{
    public class LectureUser
    {
        [Key]
        public int Id { get; set; }

        public int LectureId { get; set; }

        public virtual Lecture Lecture { get; set; }

        // Nazwa UserId
        public int SimpleUserId { get; set; }

        public virtual SimpleUser SimpleUser { get; set; }

    }
}
