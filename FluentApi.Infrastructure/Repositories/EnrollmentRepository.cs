using FluentApi.Domain;
using FluentApi.Domain.Repositories;
using FluentApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Infrastructure.Repositories;

public class EnrollmentRepository(AppDbContext context) : IEnrollmentRepository
{
    public Task<bool> ExistsAsync(Guid studentId, Guid courseId, CancellationToken ct)
        => context.StudentCourses.AnyAsync(x => x.StudentId == studentId && x.CourseId == courseId, ct);

    public async Task AddAsync(Guid studentId, Guid courseId, CancellationToken ct)
    {
        context.StudentCourses.Add(new StudentCourse(studentId, courseId));
        await context.SaveChangesAsync(ct);
    }
}