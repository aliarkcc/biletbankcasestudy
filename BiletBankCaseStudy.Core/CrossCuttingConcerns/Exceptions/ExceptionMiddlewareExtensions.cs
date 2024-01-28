using Microsoft.AspNetCore.Builder;

namespace FreelanceProductApi.Core.CrossCuttingConcerns.Exceptions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}