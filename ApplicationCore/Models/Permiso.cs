using System;
using System.Collections.Generic;

namespace ApplicationCore.Models;

public partial class Permiso
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly? FechaSolicitud { get; set; }

    public int Dias { get; set; }

    public string? Motivo { get; set; }

    public string? Estado { get; set; }

    public virtual Empleado? Empleado { get; set; } = null!;
}
