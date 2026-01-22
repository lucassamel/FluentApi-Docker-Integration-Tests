namespace FluentApi.Domain;

public class Course
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = default!;
    public List<StudentCourse> StudentCourses { get; private set; } = new();

    private Course() { } // EF

    public Course(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.", nameof(title));

        Title = title.Trim();
    }
}