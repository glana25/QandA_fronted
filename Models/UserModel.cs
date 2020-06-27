using System.ComponentModel.DataAnnotations;

namespace QandA_lesson1.Models
{
    public class UserModel
    {
        [Required]
<<<<<<< HEAD
        [StringLength(20 ,MinimumLength =5)]
        public string Username { get; set; }

        [Required]
        [StringLength (20,MinimumLength =5)]
        
=======
        [StringLength (10, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [StringLength(10, MinimumLength =3)]
>>>>>>> 0c048e398dcd67d860d27cb9e1d6df87868cd79a
        public string Password { get; set; }
    }

    public class RegisterUser : UserModel
    {
        public string ConfirmPassword { get; set; }
    }
}
