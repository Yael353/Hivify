using Microsoft.AspNetCore.Identity;

namespace Hivify.Infrastructures.Identity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
    }

}
