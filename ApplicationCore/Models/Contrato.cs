using System;
using System.Collections.Generic;

namespace ApplicationCore.Models;

public partial class Contrato
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string Tipo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual Empleado? Empleado { get; set; } = null!;
}
