namespace QandA_lesson1.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUser : UserModel
    {
        public string ConfirmPassword { get; set; }
    }
}
