using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Context
{
    public class AuthDbContext:IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var userRoleId = "82e28843-2239-4acd-9e85-0c71bf41e466";
            var contributorRoleId = "1dfb1641-47c7-47a6-b4f8-1ca9b92fbf38";

            // Creating Roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id=userRoleId,
                    Name="User",
                    NormalizedName="User".ToUpper(),
                    ConcurrencyStamp= userRoleId
                },
                new IdentityRole()
                {
                    Id = contributorRoleId,
                    Name = "Contributor",
                    NormalizedName = "Contributor".ToUpper(),
                    ConcurrencyStamp = contributorRoleId
                },

            };
            // seed roles
            builder.Entity<IdentityRole>().HasData(roles);

            //Create an admin user
            var adminUserId = "0d88f3e7-d8ad-40eb-8c9b-85e45e83bdb0";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@codepills.com",
                Email = "admin@codepills.com",
                NormalizedEmail = "admin@codepills.com".ToUpper(),
                NormalizedUserName = "admin@codepills.com".ToUpper()
            };
            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");
            builder.Entity<IdentityUser>().HasData(admin);

            // Give roles to admin

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = userRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = contributorRoleId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
