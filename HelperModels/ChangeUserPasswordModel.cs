using System.ComponentModel.DataAnnotations;

namespace keepr_c.Models
{
    public class ChangeUserPasswordModel
    {
        public int Id { get; set; }
        [MaxLength(255), EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4)]
        public string OldPassword { get; set; }
        [Required, MinLength(4)]
        public string NewPassword { get; set; }
    }
}