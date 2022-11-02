using Bearings2000.Portal.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bearings2000.Portal.Web.Data;

public class Bearings2000PortalWebContext : IdentityDbContext<AppUser>
{
    public Bearings2000PortalWebContext(DbContextOptions<Bearings2000PortalWebContext> options)
        : base(options)
    {
    }

    protected Bearings2000PortalWebContext(DbContextOptions options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
