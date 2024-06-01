using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowCaseZeeslag.Models;

namespace ShowCaseZeeslag.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<VeldGrootte> VeldGroottes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
