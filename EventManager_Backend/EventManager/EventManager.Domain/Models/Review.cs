
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventManager.Domain.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public int LectureId { get; set; }

        [ForeignKey("LectureId")]
        public virtual Lecture Lecture { get; set; }

        public int ReviewerId { get; set; }

        [ForeignKey("ReviewerId")]
        public virtual SimpleUser SimpleUser { get; set; }

        public int Rate { get; set; }

        public string Nickname { get; set; }

        public string Comment { get; set; }
    }
}
