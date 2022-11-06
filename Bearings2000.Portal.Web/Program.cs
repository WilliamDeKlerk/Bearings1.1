using Bearings2000.Portal.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bearings2000.Portal.Web.Data;
using Bearings2000.Portal.Web.Models;
using Bearings2000.Portal.Web.Services;
using Microsoft.AspNetCore.Builder;

var MyAllowSpecificOrigins = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

//primary logging dir
builder.Logging.AddFile("Logs/Bearings2000_Log-{Date}.txt");

var connectionString = builder.Configuration.GetConnectionString("Bearings2000PortalWebContextConnection") ?? throw new InvalidOperationException("Connection string 'Bearings2000PortalWebContextConnection' not found.");

builder.Services.AddDbContext<BearingsContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BearingsContext>();

builder.Services.AddTransient<IDataService, DataService>();

builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);


// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


//builder.Services.AddCors(opt =>
//{
//    opt.AddPolicy("CorsPolicy", policy =>
//    {
//        policy
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .AllowAnyOrigin()
//            .AllowCredentials()
//            .WithExposedHeaders("WWW-Authenticate", "Pagination", "Set-Cookie")
//            .WithHeaders("Content-Type", "Vary")
//            .WithMethods(new String[] { "GET", "POST" })
//            .WithOrigins(
//               "https://localhost:7236", 
//                "http://localhost:5079"

//            );

//    });
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();


app.UseRouting();
app.UseStaticFiles();
//app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapDefaultControllerRoute();
app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.MapRazorPages();

app.Run();
