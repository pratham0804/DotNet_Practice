using DotnetPractice.Repositories;
using Swashbuckle.AspNetCore;
using DotnetPractice.Services;
using DotnetPractice.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddDbContext<EnrollDBcontext>(options =>
    options.UseSqlite("Data Source=Enrolldb.db"));





// Repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();



builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<IEnrollmentService ,EnrollmentService>();

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

