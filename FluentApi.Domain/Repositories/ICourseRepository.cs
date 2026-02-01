namespace FluentApi.Domain.Repositories;

public interface ICourseRepository
{
    Task AddAsync(Course course, CancellationToken ct);
    Task<Course?> GetByIdAsync(Guid id, CancellationToken ct);
}