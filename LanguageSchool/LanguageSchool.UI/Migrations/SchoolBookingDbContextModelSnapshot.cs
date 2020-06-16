using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using LanguageSchool.Infrastructure;


namespace LanguageSchool.UI.Migrations
{
    [DbContext(typeof(SchoolBookingDbContext))]
    partial class SchoolBookingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LanguageSchool.Entities.Course", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("TrainingTime")
                    .HasColumnType("int");

                b.Property<int>("Year")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Courses");

                b.HasData(
                    new
                    {
                        Id = new Guid("3343be0f-8134-490c-9163-46358e1b4a77"),
                        Name = "Kurs Angielskiego A1",
                        TrainingTime = 350,
                        Year = 2019
                    },
                    new
                    {
                        Id = new Guid("cf92ef48-e040-4f01-9fd1-307da82ce559"),
                        Name = "Kurs Angielskiego B1",
                        TrainingTime = 450,
                        Year = 2019
                    },
                    new
                    {
                        Id = new Guid("265e0f96-e9e2-48ec-900d-d67283992990"),
                        Name = "Kurs Angielskiego C1",
                        TrainingTime = 550,
                        Year = 2019
                    });
            });

            modelBuilder.Entity("LanguageSchool.Entities.Training", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("Date")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("CourseId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("Id");

                b.HasIndex("CourseId");

                b.ToTable("Trainings");

                b.HasData(
                    new
                    {
                        Id = new Guid("ef473f01-f344-4470-8f1b-ab4637948fa6"),
                        Date = new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified),
                        MovieId = new Guid("3343be0f-8134-490c-9163-46358e1b4a77")
                    },
                    new
                    {
                        Id = new Guid("ba628c2f-47e0-4340-bd65-2c84dedef60c"),
                        Date = new DateTime(2019, 3, 10, 22, 30, 0, 0, DateTimeKind.Unspecified),
                        MovieId = new Guid("cf92ef48-e040-4f01-9fd1-307da82ce559")
                    },
                    new
                    {
                        Id = new Guid("ac287e1f-e8ed-4644-a983-2c8304a560e0"),
                        Date = new DateTime(2019, 4, 10, 18, 30, 0, 0, DateTimeKind.Unspecified),
                        MovieId = new Guid("265e0f96-e9e2-48ec-900d-d67283992990")
                    });
            });

            modelBuilder.Entity("LanguageSchool.Entities.Booking", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Email")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("PeopleCount")
                    .HasColumnType("int");

                b.Property<DateTime>("PurchesDate")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("TrainingId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("Id");

                b.HasIndex("TrainingId");

                b.ToTable("Bookings");
            });

            modelBuilder.Entity("LanguageSchool.Entities.Training", b =>
            {
                b.HasOne("LanguageSchool.Entities.Course", null)
                    .WithMany("Trainings")
                    .HasForeignKey("CourseId");
            });

            modelBuilder.Entity("LanguageSchool.Entities.Booking", b =>
            {
                b.HasOne("LanguageSchool.Entities.Training", null)
                    .WithMany("Bookings")
                    .HasForeignKey("TrainingId");
            });
#pragma warning restore 612, 618
        }
    }
}
