using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FitnessClassRegistration.Models;
using ApplicationModels.FitnessApp.Models;
using System;
using FitnessClassRegistration.Models;

namespace FitnessClassRegistration.Data
{
    public class FitnessAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FitnessClassType> FitnessClassType { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<FitnessClass> FitnessClass { get; set; }
        public DbSet<RegistrationRecord> RegistrationRecord { get; set; }
        public DbSet<Announcement> Announcement { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            FitnessClassSchema(builder);
            FitnessClassTypeSchema(builder);
            InstructorSchema(builder);
            LocationSchema(builder);
            RegistrationRecordsSchema(builder);
            AnnouncementSchema(builder);
        }
        private void AnnouncementSchema(ModelBuilder builder)
        {
            builder.Entity<Announcement>()
                .Property(a => a.Title)
                .IsRequired();

            builder.Entity<Announcement>()
                .Property(a => a.Comment)
                .IsRequired();
        }

        private void RegistrationRecordsSchema(ModelBuilder builder)
        {
            builder.Entity<RegistrationRecord>()
                .Property(r => r.UserName)
                .IsRequired();

            builder.Entity<RegistrationRecord>()
                .Property(r => r.Email)
                .IsRequired();

            builder.Entity<RegistrationRecord>()
                .Property(r => r.WaitListed)
                .IsRequired();

            builder.Entity<RegistrationRecord>()
                .HasOne(p => p.FitnessClass)
                .WithMany(p => p.RegistrationRecords)
                .HasForeignKey(p => p.FitnessClass_Id);
        }

        private void LocationSchema(ModelBuilder builder)
        {
            builder.Entity<Location>()
                .Property(r => r.Name)
                .IsRequired();
        }

        private void InstructorSchema(ModelBuilder builder)
        {
            builder.Entity<Instructor>()
                .Property(r => r.Name)
                .IsRequired();
        }

        private void FitnessClassTypeSchema(ModelBuilder builder)
        {
            builder.Entity<FitnessClassType>()
                .Property(r => r.Name)
                .IsRequired();
        }

        private void FitnessClassSchema(ModelBuilder builder)
        {
            builder.Entity<FitnessClass>()
                .Property(r => r.StartTime)
                .IsRequired();

            builder.Entity<FitnessClass>()
                .Property(r => r.EndTime)
                .IsRequired();

            builder.Entity<FitnessClass>()
                .Property(r => r.DateOfClass)
                .IsRequired();

            builder.Entity<FitnessClass>()
                .HasOne(p => p.FitnessClassType)
                .WithMany(p => p.FitnessClasses)
                .HasForeignKey(p => p.FitnessClassType_Id);

            builder.Entity<FitnessClass>()
                .HasOne(p => p.Instructor)
                .WithMany(p => p.FitnessClasses)
                .HasForeignKey(p => p.Instructor_Id);

            builder.Entity<FitnessClass>()
                .HasOne(p => p.Location)
                .WithMany(p => p.FitnessClasses)
                .HasForeignKey(p => p.Location_Id);
        }
    }
}
