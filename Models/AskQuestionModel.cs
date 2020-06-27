using System.ComponentModel.DataAnnotations;

namespace QandA_lesson1.Models
{
    public class AskQuestionModel
    {
        [Required]
        [StringLength(100,MinimumLength =5)]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Content { get; set; }
    }
}
