using FluentApi.Domain;
using FluentApi.Domain.Entities;
using FluentApi.Domain.Repositories;
using FluentApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Infrastructure.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    public async Task AddAsync(Student student, CancellationToken ct)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync(ct);
    }

    public Task<Student?> GetByIdAsync(Guid id, CancellationToken ct)
        => context.Students
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new Student(
                x.Id,
                x.Name,
                x.Profile == null ? null : new StudentProfile(x.Profile.Email, x.Profile.BirthDate)
            ))
            .FirstOrDefaultAsync(ct);

    public Task<List<Student>> GetStudentsAsync(CancellationToken ct)
    {
        return context.Students
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync(ct);
    }
}