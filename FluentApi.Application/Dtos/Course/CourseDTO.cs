namespace FluentApi.Application.Dtos.Course;

public class CourseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    //public List<StudentCourse> StudentCourses { get; private set; } = new();
}