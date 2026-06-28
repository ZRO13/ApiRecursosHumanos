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
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<SistemaRrhhContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionSql")));

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:8080")
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
app.UseCors("FrontendPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();