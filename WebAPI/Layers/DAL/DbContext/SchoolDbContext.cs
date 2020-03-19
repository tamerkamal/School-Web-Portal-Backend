using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolPortalAPI.BOL;
using SchoolPortalAPI.BOL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.Models
{
    public class SchoolDbContext : IdentityDbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options) { }

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
        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRole>().HasData(new IdentityRole { Id = "2147483645", Name = "Admin", NormalizedName = "Admin".ToUpper() });
            modelBuilder.Entity<AppRole>().HasData(new IdentityRole { Id = "3147483643", Name = "Member", NormalizedName = "Member".ToUpper() });
        }
        private void SeedAdmin(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(new IdentityUser { Id = "2147483646", Email = "admin@gmail.com", UserName = "admin@gmail.com", PasswordHash = "1234" });
            modelBuilder.Entity<AppUserRole>().HasData(new AppUserRole() { RoleId = "2147483645", UserId = "2147483646" });
        }
        private void SeedMembershipTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipType>().HasData(
            new MembershipType { MembershipTypeId = Guid.Parse("3B8DB47A-57D6-4A49-92D3-02599FD003EF"), Name = "Student" },
            new MembershipType { MembershipTypeId = Guid.Parse("CFF38BC0-1948-481E-89A5-597CAD9530A7"), Name = "Parent" },
            new MembershipType { MembershipTypeId = Guid.Parse("0041727C-9884-4A46-9690-EC1C522D3DBE"), Name = "Teacher" });
        }
    }
}
