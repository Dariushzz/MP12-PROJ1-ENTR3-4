using Microsoft.EntityFrameworkCore;
using WorkingwithSQLLiteinAsp.NETCoreWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Agregar soporte a controladores (esto es necesario para tus endpoints tipo UfceventsController)
builder.Services.AddControllers();

// 2️⃣ Registrar el contexto de base de datos con SQLite
builder.Services.AddDbContext<MiDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("UFCConnection")));

// 3️⃣ Agregar Swagger (documentación automática)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4️⃣ Middleware de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 5️⃣ HTTPS, routing y controladores
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
