using System;
using System.Collections.Generic;

namespace ApplicationCore.Models;

public partial class Asistencia
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly? HoraEntrada { get; set; }

    public TimeOnly? HoraSalida { get; set; }

    public virtual Empleado? Empleado { get; set; } = null!;
}
