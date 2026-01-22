namespace FluentApi.Domain.Repositories;

public interface IEnrollmentRepository
{
    Task<bool> ExistsAsync(Guid studentId, Guid courseId, CancellationToken ct);
    Task AddAsync(Guid studentId, Guid courseId, CancellationToken ct);
}