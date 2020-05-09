using System;
using System.Collections.Generic;

namespace QandA_lesson1.DataStore
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Answer> Answers { get; set; }
        public User User { get; set; }
    }
}