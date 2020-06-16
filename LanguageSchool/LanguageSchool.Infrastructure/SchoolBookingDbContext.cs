using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LanguageSchool.Entities;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Infrastructure
{
    public class SchoolBookingDbContext : DbContext
    {
        public SchoolBookingDbContext(DbContextOptions<SchoolBookingDbContext> options)
           : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(m =>
            {
                m.ToTable("Course");
                m.HasKey(x => x.Id);
                m.Property(e => e.Id)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Course>(v));
                m.HasMany(x => x.Trainings)
                    .WithOne()
                    .HasForeignKey(x => x.CourseId);
            });

            modelBuilder.Entity<Training>(m =>
            {
                m.ToTable("Training");
                m.HasKey(x => x.Id);
                m.Property(e => e.Id)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Training>(v));
                m.Property(e => e.CourseId)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Course>(v));
                m.HasMany(x => x.Bookings)
                    .WithOne()
                    .HasForeignKey(x => x.TrainingId);
            });

            modelBuilder.Entity<Booking>(m =>
            {
                m.ToTable("Booking");
                m.HasKey(x => x.Id);
                m.Property(e => e.Id)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Booking>(v));
                m.Property(e => e.TrainingId)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Training>(v));
            });

            var firstCourse = new Course("Kurs Angielskiego A1", 2019,350);
            var secondCourse = new Course("Kurs Angielskiego B1", 2019, 450);
            var thirdCourse = new Course("Kurs Angielskiego C1", 2019, 550);

            modelBuilder.Entity<Course>().HasData(firstCourse, secondCourse, thirdCourse);

            var firstDate = new DateTime(2019, 3, 10, 18, 30, 0);
            var secondDate = new DateTime(2019, 3, 10, 22, 30, 0);
            var thirdDate = new DateTime(2019, 4, 10, 18, 30, 0);

            var firstTraining = new Training(firstDate, firstCourse.Id);
            var secondTraining = new Training(secondDate, secondCourse.Id);
            var thirdTraining = new Training(thirdDate, thirdCourse.Id);

            modelBuilder.Entity<Training>().HasData(firstTraining, secondTraining, thirdTraining);
        }
    }
}
