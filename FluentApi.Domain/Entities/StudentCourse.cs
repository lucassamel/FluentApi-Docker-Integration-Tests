namespace FluentApi.Domain.Entities;

public class StudentCourse
{
    public Guid StudentId { get; private set; }
    public Guid CourseId { get; private set; }
    public DateTime EnrolledAtUtc { get; private set; } = DateTime.UtcNow;

    public Student Student { get; private set; } = default!;
    public Course Course { get; private set; } = default!;

    private StudentCourse() { } // EF

    public StudentCourse(Guid studentId, Guid courseId)
    {
        if (studentId == Guid.Empty) throw new ArgumentException("StudentId invalid.");
        if (courseId == Guid.Empty) throw new ArgumentException("CourseId invalid.");
        StudentId = studentId;
        CourseId = courseId;
    }
}