using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApplicationCore.Models;

public partial class Asistencia
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly? HoraEntrada { get; set; }

    public TimeOnly? HoraSalida { get; set; }
    [JsonIgnore] // <--- AGREGA ESTO AQUÍ
    public virtual Empleado? Empleado { get; set; } = null!;
}
