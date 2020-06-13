using System;

namespace QandA_lesson1.DataStore
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Question Question { get; set; }
    }
}