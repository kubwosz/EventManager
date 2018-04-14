using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EventManager.Api.ViewModels
{
    public class CreateReviewViewModel
    {
        [Required]
        public int LectureId { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public int Rate { get; set; }

        [Required]
        public int ReviewerId { get; set; }
    }
}
