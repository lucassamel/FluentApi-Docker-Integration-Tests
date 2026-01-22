using FluentApi.Domain;
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
            .Include(x => x.Profile)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
}