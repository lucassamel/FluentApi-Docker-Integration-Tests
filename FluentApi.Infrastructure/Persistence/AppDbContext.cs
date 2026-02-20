using FluentApi.Domain;
using FluentApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FluentApi.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<StudentCourse> StudentCourses => Set<StudentCourse>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Student>(e =>
        {
            e.ToTable("Students");
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(200).IsRequired();

            // 1:1 Student -> Profile (Profile PK = StudentId)
            e.HasOne(x => x.Profile)
                .WithOne(x => x.Student)
                .HasForeignKey<StudentProfile>(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<StudentProfile>(e =>
        {
            e.ToTable("StudentProfiles");
            e.HasKey(x => x.StudentId);
            e.Property(x => x.Email).HasMaxLength(320).IsRequired();
            e.HasIndex(x => x.Email).IsUnique();

            // DateOnly mapping
            e.Property(x => x.BirthDate).HasConversion(
                v => v.ToDateTime(TimeOnly.MinValue),
                v => DateOnly.FromDateTime(v)
            );
        });

        b.Entity<Course>(e =>
        {
            e.ToTable("Courses");
            e.HasKey(x => x.Id);
            e.Property(x => x.Title).HasMaxLength(200).IsRequired();
            e.HasIndex(x => x.Title).IsUnique();
        });

        b.Entity<StudentCourse>(e =>
        {
            e.ToTable("StudentCourses");
            e.HasKey(x => new { x.StudentId, x.CourseId });

            e.HasOne(x => x.Student)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.StudentId);

            e.HasOne(x => x.Course)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.CourseId);
        });
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();
#endif
    }
}