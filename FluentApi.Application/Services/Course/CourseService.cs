using FluentApi.Application.Dtos.Course;
using FluentApi.Domain.Repositories;

namespace FluentApi.Application.Services.Course;

public class CourseService(ICourseRepository coursesRepository) : ICourseService
{
    public async Task<Guid> CreateCourseAsync(string title, CancellationToken ct)
    {
        var course = new Domain.Entities.Course(title);
        await coursesRepository.AddAsync(course, ct);
        return course.Id;
    }

    public async Task<IEnumerable<CourseDto>> GetCoursesAsync(CancellationToken ct)
    {
        var courses = await coursesRepository.GetAllAsync(ct);

        if (courses == null)
            return null;
        
        var coursesDto = courses.Select<Domain.Entities.Course, CourseDto>(x => x);
        
        return coursesDto;
    }
}
