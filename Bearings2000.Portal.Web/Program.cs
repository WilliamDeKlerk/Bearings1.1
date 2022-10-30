using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bearings2000.Portal.Web.Data;
using Bearings2000.Portal.Web.Models;
using Bearings2000.Portal.Web.Services;


var builder = WebApplication.CreateBuilder(args);

//primary logging dir
builder.Logging.AddFile("Logs/Bearings2000_Log-{Date}.txt");

var connectionString = builder.Configuration.GetConnectionString("Bearings2000PortalWebContextConnection") ?? throw new InvalidOperationException("Connection string 'Bearings2000PortalWebContextConnection' not found.");

builder.Services.AddDbContext<BearingsContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BearingsContext>();

builder.Services.AddTransient<IDataService,DataService>();

// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
