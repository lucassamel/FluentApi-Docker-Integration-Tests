using FluentApi.Application.Dtos.Course;

namespace FluentApi.Application.Services.Course;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetCoursesAsync(CancellationToken ct);
}