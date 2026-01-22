using FluentApi.Domain.Repositories;
using FluentApi.Infrastructure.Persistence;
using FluentApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluentApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("SqlServer")));
        
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

        return services;
    }
}