using ApplicationCore.Data;
using ApplicationCore.Services;
using ApplicationCore.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();
builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<IContratoService, ContratoService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IEvaluacionDesempenoService, EvaluacionDesempenoService>();
builder.Services.AddScoped<INominaService, NominaService>();
builder.Services.AddScoped<IPermisoService, PermisoService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<SistemaRrhhContext>(options =>
////    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<SistemaRrhhContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionSql")));
// Modifica tu Program.cs solo para que corra la migración
//builder.Services.AddDbContext<SistemaRrhhContext>(options =>
//    options.UseNpgsql("Host=ep-flat-cake-atk4lb8o-pooler.c-9.us-east-1.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_a8RtW3OcshFL;Ssl Mode=Require;Trust Server Certificate=true;"));
builder.Services.AddDbContext<SistemaRrhhContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("ConexionSql")));

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp", policy =>
    {
        policy.WithOrigins("https://rrhh1-app.vercel.app/")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS (antes de Authorization y MapControllers)
app.UseCors("AllowWebApp");

app.UseAuthorization();

app.MapControllers();

app.Run(); 
