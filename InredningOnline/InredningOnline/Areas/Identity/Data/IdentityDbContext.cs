using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InredningOnline.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InredningOnline.Data
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string USER_ID_1 = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            //const string USER_ID_2 = "e8805cd4-1452-4c76-bd35-ab5cb846de11";

            const string ADMIN_ROLE_ID = ADMIN_ID;
            const string USER_ROLE_ID = USER_ID_1;

            


            // seed admin and user roles
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });


            // create users
            var admin = new ApplicationUser
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = false,
                FirstName = "Masoomeh",
                LastName = "Ghasemi",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                LockoutEnabled = true,
            };

            var user1 = new ApplicationUser
            {
                Id = USER_ID_1,
                Email = "user@user.com",
                NormalizedEmail = "USER@USER.COM",
                EmailConfirmed = false,
                FirstName = "Masoomeh",
                LastName = "Ghasemi",
                UserName = "user@user.com",
                NormalizedUserName = "USER@USER.COM",
                LockoutEnabled = true,
            };

            // set passwords
            PasswordHasher<ApplicationUser> password = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = password.HashPassword(admin, "Test2020!");

            user1.PasswordHash = password.HashPassword(user1, "Test2020!");

            //seed user
            builder.Entity<ApplicationUser>().HasData(admin);


            //set ADMIN role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

            //seed user
            builder.Entity<ApplicationUser>().HasData(user1);


            //set USER role to user1
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID_1
            });
        }
    }
}
