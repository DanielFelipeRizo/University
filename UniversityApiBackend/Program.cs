//1. using para usar entity framework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;

var builder = WebApplication.CreateBuilder(args);


//2. TODO: conexion sqlserever
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//3. agregar contexto
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));



// Add services to the container.

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
