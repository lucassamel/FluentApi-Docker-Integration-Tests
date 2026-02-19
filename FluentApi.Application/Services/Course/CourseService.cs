using FluentApi.Application.Dtos.Course;
using FluentApi.Domain.Repositories;

namespace FluentApi.Application.Services.Course;

public class CourseService(ICourseRepository courses) : ICourseService
{
    public async Task<Guid> CreateCourseAsync(string title, CancellationToken ct)
    {
        var course = new Domain.Course(title);
        await courses.AddAsync(course, ct);
        return course.Id;
    }

    public Task<IEnumerable<CourseDto>>  GetCoursesAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}