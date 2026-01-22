using FluentApi.Domain;
using FluentApi.Domain.Repositories;


namespace FluentApi.Application.Students;

public class StudentService(IStudentRepository studentRepository, IEnrollmentRepository enrollmentRepository)
{
    public async Task<Guid> CreateStudentAsync(string name, string email, DateOnly birthDate, CancellationToken ct)
    {
        var student = new Student(name);
        student.SetProfile(email, birthDate);

        await studentRepository.AddAsync(student, ct);
        return student.Id;
    }

    public async Task EnrollAsync(Guid studentId, Guid courseId, CancellationToken ct)
    {
        if (await enrollmentRepository.ExistsAsync(studentId, courseId, ct))
            return;

        await enrollmentRepository.AddAsync(studentId, courseId, ct);
    }

    
}