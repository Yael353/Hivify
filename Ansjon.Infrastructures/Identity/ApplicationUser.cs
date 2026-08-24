using Microsoft.AspNetCore.Identity;

namespace Ansjon.Infrastructures.Identity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
    }

}
