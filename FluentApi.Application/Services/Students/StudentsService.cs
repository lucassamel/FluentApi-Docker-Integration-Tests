using FluentApi.Application.Dtos.Student;
using FluentApi.Domain;
using FluentApi.Domain.Repositories;

namespace FluentApi.Application.Services.Students;

public class StudentService(IStudentRepository studentRepository, IEnrollmentRepository enrollmentRepository,
    ICourseRepository courseRepository) : IStudentService
{
    public async Task<Guid> CreateStudentAsync(StudentRequest studentRequest, CancellationToken ct)
    {
        var student = new Student(studentRequest.Name);
        student.SetProfile(studentRequest.Email, studentRequest.DateOfBirth);

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

    public async Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken ct)
    {
        var students = await studentRepository.GetStudentsAsync(ct);
        
        return students.Select<Student, StudentDto>(x => x);
    }

    public async Task<StudentDto> GetByIdAsync(Guid studentId, CancellationToken ct)
    {
        var student = await studentRepository.GetByIdAsync(studentId, ct);
        
        if (student is null) throw new InvalidOperationException("Student not found.");
        
        return student;
    }
}