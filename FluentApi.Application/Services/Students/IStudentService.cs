using FluentApi.Application.Dtos.Student;

namespace FluentApi.Application.Services.Students;

public interface IStudentService
{
    Task<Guid> CreateStudentAsync(StudentRequest studentRequest, CancellationToken ct);
    Task EnrollAsync(Guid studentId, Guid courseId, CancellationToken ct);
    Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken ct);
    Task<StudentDto> GetByIdAsync(Guid studentId, CancellationToken ct);
}