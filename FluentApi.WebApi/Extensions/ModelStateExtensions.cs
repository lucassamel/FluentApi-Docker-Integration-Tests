using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FluentApi.Api.Extensions;

public static class  ModelStateExtensions
{
    public static IEnumerable<string> GetErrors(this ModelStateDictionary modelstate)
        => modelstate.Values.SelectMany(values => values.Errors).Select(error => error.ErrorMessage);
}