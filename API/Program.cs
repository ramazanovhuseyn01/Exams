using Application;
using Application.Features.Handlers.Exam;
using Application.Mappings;
using Application.Service.Implementations;
using Application.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Data;
using Repository.Repositories.Implementations;
using Repository.Repositories.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.ServiceDescriptors();


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
