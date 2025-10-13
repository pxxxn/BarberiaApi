using Barberia.Infrastructure.Context;
using Barberia.Application.Interfaces;
using Barberia.Infrastructure.Repositories;
using Barberia.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔗 Conexión SQL Server
builder.Services.AddDbContext<BarberiaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BarberiaConnection")));

// 🧩 Inyección de dependencias
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// 🌐 Habilitar CORS para permitir peticiones desde cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🌐 Activar CORS antes de la autorización
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
