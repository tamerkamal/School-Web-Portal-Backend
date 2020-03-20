using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolPortalAPI.BOL;
using SchoolPortalAPI.BOL.Security;
using System;

namespace SchoolPortalAPI.Models
{
    public class SchoolDbContext : IdentityDbContext
    {
        public SchoolDbContext(DbContextOptions options)
            : base(options) { }

        #region Tables
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);
            SeedMembershipTypes(modelBuilder);
            SeedAdmin(modelBuilder);
        }

        #region Helper Methods
        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRole>().HasData(new IdentityRole { Id = "2147483645", Name = "Admin", NormalizedName = "Admin".ToUpper() });
            modelBuilder.Entity<AppRole>().HasData(new IdentityRole { Id = "3147483643", Name = "Member", NormalizedName = "Member".ToUpper() });
            modelBuilder.Entity<AppRole>().HasData(new IdentityRole { Id = "4147483644", Name = "Student", NormalizedName = "Student".ToUpper() });
            modelBuilder.Entity<AppRole>().HasData(new IdentityRole { Id = "5147483645", Name = "Parent", NormalizedName = "Parent".ToUpper() });
            modelBuilder.Entity<AppRole>().HasData(new IdentityRole { Id = "6147483646", Name = "Teacher", NormalizedName = "Teacher".ToUpper() });
        }
        private void SeedAdmin(ModelBuilder modelBuilder)
        {
            AppUser user = new AppUser();
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<AppUser>().HasData(new IdentityUser
            {
                Id = "2147483646",
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                PasswordHash = hasher.HashPassword(user, "1234"),
                NormalizedUserName = ("admin@gmail.com").ToUpper(),
                NormalizedEmail = ("admin@gmail.com").ToUpper()
            }); ;
            modelBuilder.Entity<AppUserRole>().HasData(new AppUserRole() { RoleId = "2147483645", UserId = "2147483646" });
        }
        private void SeedMembershipTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipType>().HasData(
            new MembershipType { MembershipTypeId = Guid.Parse("3B8DB47A-57D6-4A49-92D3-02599FD003EF"), Name = "Student" },
            new MembershipType { MembershipTypeId = Guid.Parse("CFF38BC0-1948-481E-89A5-597CAD9530A7"), Name = "Parent" },
            new MembershipType { MembershipTypeId = Guid.Parse("0041727C-9884-4A46-9690-EC1C522D3DBE"), Name = "Teacher" });
        }
        #endregion
    }
}
