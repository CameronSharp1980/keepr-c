using System.ComponentModel.DataAnnotations;

namespace keepr_c.Models
{
    public class RegisterUserModel
    {
        [Required, MaxLength(20)]
        public string Username { get; set; }
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4)]
        public string Password { get; set; }
        [Required, MaxLength(255)]
        public string AvatarUrl { get; set; }
        [Required, MaxLength(255)]
        public string FirstName { get; set; }
        [Required, MaxLength(255)]
        public string LastName { get; set; }
    }
}