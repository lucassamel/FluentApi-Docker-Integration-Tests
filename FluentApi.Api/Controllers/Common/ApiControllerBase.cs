using FluentApi.Api.Extensions;
using FluentApi.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FluentApi.Api.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public class ApiControllerBase : ControllerBase
{
    protected Response<IEnumerable<string>> ModelStateBadRequest(ModelStateDictionary modelstate)
        => new(modelstate.GetErrors());

    protected NotFoundObjectResult NotFoundCustom()
        => NotFound(new Response<string>("A consulta não retornou dados."));
}