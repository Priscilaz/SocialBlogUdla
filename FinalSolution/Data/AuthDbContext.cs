using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalSolution.Data
{
    public class AuthDbContext : IdentityDbContext
    {

        public AuthDbContext (DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Rol Usuario
            var adminRolId = "dc7236d4-75fa-44cd-ac65-3e80792da8e5";
            var superAdminRoleId = "b6636e35-5215-4b9a-8c56-896396b693f4";
            var usuarioRolId = "383cd0da-4d07-4728-b767-50a886bbd2a6";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",

                    Id = adminRolId,
                    ConcurrencyStamp = adminRolId
                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",

                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = usuarioRolId,
                    ConcurrencyStamp = usuarioRolId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
            //Seed superadmin

            var superAdminId = "aa692445-a241-4bef-9f9d-aeec35c4bfcc";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@udla.com",
                Email = "superadmin@udla.com",
                NormalizedEmail = "superadmin@udla.com".ToUpper(),
                NormalizedUserName = "superadmin@udla.com".ToUpper(),
                Id = superAdminId
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Superadmin123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Dando roles al Admin como User
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRolId,
                    UserId = superAdminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId = usuarioRolId,
                    UserId = superAdminId,
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }


    }
}
