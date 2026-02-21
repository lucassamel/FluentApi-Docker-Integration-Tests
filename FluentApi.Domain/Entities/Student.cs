using FluentApi.Domain.Entities;

namespace FluentApi.Domain;

public class Student
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = default!;
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;

    // 1:1
    public StudentProfile? Profile { get; private set; }

    // N:N
    public List<StudentCourse?> StudentCourses { get; private set; } = new();

    private Student() { } // EF

    public Student(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        Name = name.Trim();
    }
    
    public Student(Guid id ,string name, StudentProfile? profileStudent)
    {
        Id = id; 
        Name = name;
        Profile = profileStudent;
    }
    public void SetProfile(string email, DateOnly birthDate)
    {
        Profile = new StudentProfile(Id, email, birthDate);
    }

    
}