using DotnetPractice.Repositories;
using Swashbuckle.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

    // builder.Services.AddTransient<IStudentRepository,StudentRepository>();
    // builder.Services.AddTransient<ICourseRepository,CourseRepository>();
    // builder.Services.AddTransient<IEnrollmentRepository,EnrollmentRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();



app.Run();

