namespace FluentApi.Application.Dtos.Contracts;


public record CreateStudentRequest(string Name, string Email, DateOnly BirthDate);
public record UpdateStudentRequest(string Name);
public record UpdateStudentProfileRequest(string Email, DateOnly BirthDate);
public record EnrollStudentRequest(Guid CourseId);
