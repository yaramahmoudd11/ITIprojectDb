using Microsoft.AspNetCore.Identity;

namespace ITIprojectDb.Models.Auth
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
