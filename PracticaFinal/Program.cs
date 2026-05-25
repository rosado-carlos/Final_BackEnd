using PracticaFinal.Services;
using Microsoft.EntityFrameworkCore;
using PracticaFinal.Interfaces;
using PracticaFinal.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
// Aquí agregamos la inyección de dependencia de nuestros servicios
// sin esto, los controladores no van a servir ya que no se inyecta el constructor o el objeto
// que permite ir y llamar la capa lógica que tiene las operaciones CRUD o demás reglas de negocio
builder.Services.AddScoped<IRespuestasService, RespuestasService>();
builder.Services.AddScoped<IPreguntasService, PreguntasService>();
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
