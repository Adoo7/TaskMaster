using Microsoft.EntityFrameworkCore;
using TaskMasterBusinessObjects;
using Microsoft.AspNetCore.Identity;
using WebFormTaskMaster.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskMasterDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddDbContext<WebFormTaskMasterContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
