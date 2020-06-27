using System.ComponentModel.DataAnnotations;

namespace QandA_lesson1.Models
{
    public class UserModel
    {
        [Required]
        [StringLength (10, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [StringLength(10, MinimumLength =3)]
        public string Password { get; set; }
    }

    public class RegisterUser : UserModel
    {
        public string ConfirmPassword { get; set; }
    }
}
