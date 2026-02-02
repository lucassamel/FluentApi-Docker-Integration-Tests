using FluentApi.Application.Course;
using FluentApi.Application.Students;
using FluentApi.Infrastructure;
using FluentApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");

builder.Services
    .AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// aplica migrations automaticamente (opcional)
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//
//     await db.Database.MigrateAsync();
// }

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

