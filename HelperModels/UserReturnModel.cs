using System.Collections.Generic;
using System.Security.Claims;

namespace keepr_c.Models
{
    public class UserReturnModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        internal ClaimsPrincipal SetClaims()
        {
            var claims = new List<Claim> {
                        //Shouldn't lookup by email?
                        // new Claim(ClaimTypes.Email, Email),
                        new Claim(ClaimTypes.Name, Id.ToString())
                    };
            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            return principal;
        }
    }
}