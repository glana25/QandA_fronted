using System.Collections.Generic;

namespace QandA_lesson1.DataStore
{
    public class User
    {
        public User()
        {
            Questions = new List<Question>();
            Answers = new List<Answer>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}