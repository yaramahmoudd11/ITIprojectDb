using Microsoft.AspNetCore.Identity;

namespace ITIprojectDb.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string CustomUserName { get; set; }
    }
}
