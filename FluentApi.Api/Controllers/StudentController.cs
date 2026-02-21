using FluentApi.Api.Controllers.Common;
using FluentApi.Api.Extensions;
using FluentApi.Application.Dtos;
using FluentApi.Application.Dtos.Student;
using FluentApi.Application.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace FluentApi.Api.Controllers;

public class StudentController(IStudentService studentService) : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<StudentDto>>> GetAll(CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(new Response<IEnumerable<string>>(ModelState.GetErrors()));
        
        var students = await studentService.GetAllAsync(ct);
        return  Ok(new Response<IEnumerable<StudentDto>>(students));
    }
    
    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<List<StudentDto>>> GetStudentById(Guid id,CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(new Response<IEnumerable<string>>(ModelState.GetErrors()));
        
        var student = await studentService.GetByIdAsync(id,ct);
        
        return  Ok(new Response<StudentDto>(student));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(StudentRequest studentRequest, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(new Response<IEnumerable<string>>(ModelState.GetErrors()));
        
        var studentAdded = await studentService.CreateStudentAsync(studentRequest, ct);

        return Ok(new Response<Guid>(studentAdded));
    }
}