using QandA_lesson1.DataStore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QandA_lesson1.Models
{
    public class AnswersModel 
    {
       
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionUsername { get; set; }
        public DateTime QuestionDateCreated { get; set; }
<<<<<<< HEAD

        [Required]
        [StringLength(500, MinimumLength = 5)]
=======
        [Required]
        [StringLength(500)]
>>>>>>> 0c048e398dcd67d860d27cb9e1d6df87868cd79a
        public string Answer { get; set; }
        public List<Answer> QuestionAnswers { get; set; }
    }
}
