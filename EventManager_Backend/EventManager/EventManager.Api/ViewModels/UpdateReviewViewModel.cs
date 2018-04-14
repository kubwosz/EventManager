

namespace EventManager.Api.ViewModels
{
    public class UpdateReviewViewModel
    {
        public int Id { get; set; }

        public int LectureId { get; set; }

        public string Comment { get; set; }

        public string Nickname { get; set; }

        public int Rate { get; set; }

        public int ReviewerId { get; set; }
    }
}
