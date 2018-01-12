using System.ComponentModel.DataAnnotations;

namespace keepr_c.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, MinLength(1)]
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

        internal UserReturnModel GetReturnModel()
        {
            return new UserReturnModel()
            {
                Id = Id,
                Username = Username,
                Email = Email,
                AvatarUrl = AvatarUrl,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}