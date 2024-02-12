using KiwiLadyShoes.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KiwiLadyShoes.Areas.Identity.Data;

public class IdentityContext : IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }
    //replacing the next code block Ira, Victor, 13/10/23
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        base.OnModelCreating(builder);
        //this.SeedUsers(builder);
        //this.SeedRoles(builder);
        //this.SeedUserRoles(builder);
        // Create ROLES
        List<IdentityRole> roles = new List<IdentityRole>() {
          new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
          new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" },
         new IdentityRole { Name = "Salesperson", NormalizedName = "SALESPERSON" },
          new IdentityRole { Name = "Visitor", NormalizedName = "VISITOR" }
          };
        builder.Entity<IdentityRole>().HasData(roles);

        // Create USERS
        var passwordHasher = new PasswordHasher<AppUser>();
        List<AppUser> users = new List<AppUser>() {
             new AppUser {
                 FirstName="Admin",
                 LastName="admin",
                 PhoneNumber="0210888888",
                 Birthday=DateTime.Now,
                 UserName = "administrator@example.com",
                 NormalizedUserName = "ADMINISTRATOR@EXAMPLE.COM",
                 Email = "administrator@example.com",
                 NormalizedEmail = "ADMINISTRATOR@EXAMPLE.COM",
                 EmailConfirmed=true,
             },
             new AppUser {
                 FirstName="manager",
                 LastName="manager",
                 PhoneNumber="0210888888",
                 Birthday=DateTime.Now,
                 UserName = "manager@example.com",
                 NormalizedUserName = "MANAGER@EXAMPLE.COM",
                 Email = "manager@example.com",
                 NormalizedEmail = "MANAGER@EXAMPLE.COM",
                 EmailConfirmed=true
             },
             new AppUser {
                 FirstName="salesperson",
                 LastName="salesperson",
                 PhoneNumber="0210888888",
                 Birthday=DateTime.Now,
                 UserName = "salesperson@example.com",
                 NormalizedUserName = "SALESPERSON@EXAMPLE.COM",
                 Email = "salesperson@example.com",
                 NormalizedEmail = "SALESPERSON@EXAMPLE.COM",
                 EmailConfirmed=true
             },
             new AppUser {
                 FirstName="visitor",
                 LastName="visitor",
                 PhoneNumber="0210888888",
                 Birthday=DateTime.Now,
                 UserName = "visitor@example.com",
                 NormalizedUserName = "VISITOR@EXAMPLE.COM",
                 Email = "visitor@example.com",
                 NormalizedEmail = "VISITOR@EXAMPLE.COM",
                 EmailConfirmed=true
             }
         };
        builder.Entity<AppUser>().HasData(users);

        // Add password to users
        //var passwordHasher = new PasswordHasher<IdentityUser>();
        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Password@123");
        users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Password@123");
        users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Password@123");
        users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Password@123");

        // Add roles to user
        List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[0].Id,
            RoleId = roles.First(q => q.Name == "Administrator").Id
        });
        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[1].Id,
            RoleId = roles.First(q => q.Name == "Manager").Id
        });
        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[2].Id,
            RoleId = roles.First(q => q.Name == "Salesperson").Id
        });
        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[3].Id,
            RoleId = roles.First(q => q.Name == "Visitor").Id
        });
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }

}
