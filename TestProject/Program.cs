using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.DTO;
using TestProject.Models;
using TestProject.Services.DepartmentServices;
using TestProject.Services.EmployeeServices;
using TestProject.Services.ProgramingLanguageServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<EmployeeDTO, Employee>();
    cfg.CreateMap<ProgramingLanguageDTO, ProgramingLanguage>();
    cfg.CreateMap<DepartmentDTO, Department>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestProjectContext"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentServices, DepartmentService>();
builder.Services.AddScoped<IProgramingLanguageServices, ProgramingLanguageServices>();
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
