using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection.Emit;
using Xmoor.Models;

namespace Xmoor.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        

        /// <summary>
        /// As the NI number is unique, a unique constaint is added to the database.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StaffPersonalDetails>().HasIndex(user => user.NationalInsuranceNumber).IsUnique();
            builder.Entity<StaffPersonalDetails>().Property(user => user.Id).ValueGeneratedOnAdd().UseIdentityColumn(1000, 1);
        }

        public DbSet<Salary> Salary { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<StaffPersonalDetails> StaffPersonalDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<ShiftRecord> ShiftRecords { get; set; }
        public DbSet<Holidays> Holidays { get; set; }
        public DbSet<HolidayRecord> HolidayRecords { get; set; }

    }
}