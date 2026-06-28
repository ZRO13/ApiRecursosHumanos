using System;
using System.Collections.Generic;

namespace ApplicationCore.Models;

public partial class EvaluacionDesempeno
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly FechaEvaluacion { get; set; }

    public int Puntuacion { get; set; }

    public string? Comentarios { get; set; }

    public virtual Empleado? Empleado { get; set; } = null!;
}
