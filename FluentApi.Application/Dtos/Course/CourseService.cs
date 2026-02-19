using FluentApi.Domain.Repositories;

namespace FluentApi.Application.Course;

public class CourseService(ICourseRepository courses)
{
    public async Task<Guid> CreateCourseAsync(string title, CancellationToken ct)
    {
        var course = new Domain.Course(title);
        await courses.AddAsync(course, ct);
        return course.Id;
    }
}