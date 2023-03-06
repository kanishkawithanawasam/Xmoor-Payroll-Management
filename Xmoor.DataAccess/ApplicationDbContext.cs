using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;
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

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
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
        public DbSet<RoleApplications> Applications { get; set; }
        public DbSet<RoleOpennings> RoleOpennings { get; set;}
        public DbSet<ApplicationUpdateHistory> ApplicationUpdateHistory { get; set; }
        public DbSet<RegistrationLog> RegistrationLog { get; set; }

    }

    /// <summary>
    /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
    /// </summary>
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        { }
    }
}