namespace FluentApi.Application.Dtos.Student;

public class StudentDto
{
    public string Name { get; set; } = string.Empty;
    
    public static implicit operator StudentDto (Domain.Student student)
    {
        return new StudentDto
        {
            Name = student.Name
        };
    }
}

public record StudentRequest(string Name, string Email, DateOnly DateOfBirth);