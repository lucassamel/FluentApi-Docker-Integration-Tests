using FluentApi.Domain;
using FluentApi.Domain.Repositories;


namespace FluentApi.Application.Students;

public class StudentService(IStudentRepository studentRepository, IEnrollmentRepository enrollmentRepository,
    ICourseRepository courseRepository)
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
        // valida se existem (opcional, mas bom)
        var student = await studentRepository.GetByIdAsync(studentId, ct);
        if (student is null) throw new InvalidOperationException("Student not found.");

        var course = await courseRepository.GetByIdAsync(courseId, ct);
        if (course is null) throw new InvalidOperationException("Course not found.");

        if (await enrollmentRepository.ExistsAsync(studentId, courseId, ct))
            return;

        await enrollmentRepository.AddAsync(studentId, courseId, ct);
    }

    
}