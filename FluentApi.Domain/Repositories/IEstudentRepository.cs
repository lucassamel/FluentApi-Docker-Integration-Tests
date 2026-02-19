namespace FluentApi.Domain.Repositories;

public interface IStudentRepository
{
    Task AddAsync(Student student, CancellationToken ct);
    Task<Student?> GetByIdAsync(Guid id, CancellationToken ct);
    
    void Remove(Student student);
    Task<int> SaveChangesAsync(CancellationToken ct);
    Task<List<Student>> GetStudentsAsync(CancellationToken ct);
}