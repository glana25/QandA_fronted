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

        [Required]
        [StringLength(500)]
        public string Answer { get; set; }
        public List<Answer> QuestionAnswers { get; set; }
    }
}
