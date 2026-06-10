using Ansjon.Core.Entities;
using Ansjon.Infrastructures.SqlDatabase;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;




namespace Ansjon.Infrastructures.SqlDatabase
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Feed> Feeds { get; set; }
    }
}
