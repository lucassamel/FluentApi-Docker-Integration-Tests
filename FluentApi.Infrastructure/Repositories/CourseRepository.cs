using FluentApi.Domain;
using FluentApi.Domain.Repositories;
using FluentApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Infrastructure.Repositories;

public class CourseRepository(AppDbContext context) : ICourseRepository
{
    public async Task AddAsync(Course course, CancellationToken ct)
    {
        context.Courses.Add(course);
        await context.SaveChangesAsync(ct);
    }

    public Task<Course?> GetByIdAsync(Guid id, CancellationToken ct)
        => context.Courses.FirstOrDefaultAsync(x => x.Id == id, ct);
}