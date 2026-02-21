namespace FluentApi.Domain.Entities;

public class StudentProfile
{
    public Guid StudentId { get; private set; }
    public string Email { get; private set; } = default!;
    public DateOnly BirthDate { get; private set; }

    public Student Student { get; private set; } = default!;

    private StudentProfile() { } // EF

    public StudentProfile(Guid studentId, string email, DateOnly birthDate)
    {
        if (studentId == Guid.Empty) throw new ArgumentException("StudentId invalid.");
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email is required.");
        if (!email.Contains('@')) throw new ArgumentException("Email invalid.");

        StudentId = studentId;
        Email = email.Trim().ToLowerInvariant();
        BirthDate = birthDate;
    }

    public StudentProfile(string profileEmail, DateOnly profileBirthDate)
    {
        Email = profileEmail.Trim().ToLowerInvariant();
        BirthDate = profileBirthDate;
    }
}