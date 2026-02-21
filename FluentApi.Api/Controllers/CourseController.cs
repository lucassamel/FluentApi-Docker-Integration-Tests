using FluentApi.Api.Controllers.Common;
using FluentApi.Api.Extensions;
using FluentApi.Application.Dtos;
using FluentApi.Application.Dtos.Course;
using FluentApi.Application.Services.Course;
using Microsoft.AspNetCore.Mvc;

namespace FluentApi.Api.Controllers;

public class CourseController(ICourseService courseService) : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<CourseDto>>> GetAll(CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(new Response<IEnumerable<string>>(ModelState.GetErrors()));
        
        var courses = await courseService.GetCoursesAsync(ct);
        
        return  Ok(new Response<IEnumerable<CourseDto>>(courses));
    }

    [HttpPost]
    public async Task<ActionResult<CourseDto>> Create(CourseRequest courseDto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(new Response<IEnumerable<string>>(ModelState.GetErrors()));

        var courseDtoAdded = await courseService.AddCourseAsync(courseDto, ct);
        
        return Ok(new Response<CourseDto>(courseDtoAdded));
    }
}