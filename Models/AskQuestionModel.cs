using System.ComponentModel.DataAnnotations;

namespace QandA_lesson1.Models
{
    public class AskQuestionModel
    {
        [Required]
<<<<<<< HEAD
        [StringLength(100,MinimumLength =5)]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
=======
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
>>>>>>> 0c048e398dcd67d860d27cb9e1d6df87868cd79a
        public string Content { get; set; }
    }
}
