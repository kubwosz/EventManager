namespace EventManager.Api.ViewModels
{
    public class CreateReviewViewModel
    {
        public int LectureId { get; set; }

        public string Comment { get; set; }

        public string Nickname { get; set; }

        public int Rate { get; set; }

        public int ReviewerId { get; set; }
    }
}
