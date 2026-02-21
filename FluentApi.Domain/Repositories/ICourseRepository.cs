using FluentApi.Domain.Entities;

namespace FluentApi.Domain.Repositories;

public interface ICourseRepository
{
    Task<Course> AddAsync(Course course, CancellationToken ct);
    Task<Course?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IEnumerable<Course?>> GetAllAsync(CancellationToken ct);
}