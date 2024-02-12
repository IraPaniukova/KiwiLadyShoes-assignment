using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KiwiLadyShoes.Areas.Identity.Data;
using KiwiLadyShoes.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies; //added by Ira for google authentication, 13/11/23
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims; //Added for Claims in Google option, Ira


var builder = WebApplication.CreateBuilder(args);
// rename string, Ira, Victor, 13/10/23
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//settings for external authentication Google Ira, 13/11/23--------------------
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie()
.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
{
    options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
    options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;

    //-- trying to replace NULLs in DB, but it didn't help:
    //options.Events = new OAuthEvents
    //{
    //    OnCreatingTicket = context =>
    //    {
    //        // Custom logic to handle additional fields
    //        var identity = (ClaimsIdentity)context.Principal.Identity;

    //        // Check if FirstName claim is present
    //        var firstNameClaim = identity.FindFirst("FirstName");
    //        if (firstNameClaim == null)
    //        {
    //            identity.AddClaim(new Claim("FirstName", "DefaultFirstName"));
    //        }

    //        // Check if LastName claim is present
    //        var lastNameClaim = identity.FindFirst("LastName");
    //        if (lastNameClaim == null)
    //        {
    //            identity.AddClaim(new Claim("LastName", "DefaultLastName"));
    //        }

    //        return Task.CompletedTask;
    //    }
    //};
    //-- trying to replace NULLs in DB (another option), but it didn't help:
    //options.Scope.Add("openid");
    //options.Scope.Add("profile");
    //options.Scope.Add("email");
    //options.ClaimActions.MapJsonKey("FirstName", "DefaultName");
    //options.ClaimActions.MapJsonKey("LastName", "DefaultName");
});
//-------------------------------------------------------


builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));

//registered added context FS23_Group1_ProjectContext
builder.Services.AddDbContext<FS23_Group1_ProjectContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()   //Ira,Victor
    .AddEntityFrameworkStores<IdentityContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Added for Session , Ira 8/11/23:
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//Added for Session , Ira 8/11/23:
app.UseSession();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();   //Ira,Victor, 13/10/23
app.Run();
