using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebFormTaskMaster.Areas.Identity.Data;

namespace WebFormTaskMaster.Data;

public class WebFormTaskMasterContext : IdentityDbContext<WebFormTaskMasterUser>
{
    public WebFormTaskMasterContext(DbContextOptions<WebFormTaskMasterContext> options)
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
