
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventManager.Domain.Models
{
    public class LectureUser
    {
        [Key]
        public int Id { get; set; }

        public int LectureId { get; set; }

        [ForeignKey("LectureId")]
        public virtual Lecture Lecture { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual SimpleUser SimpleUser { get; set; }

    }
}
