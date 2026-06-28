using System;
using System.Collections.Generic;

namespace ApplicationCore.Models;

public partial class Nomina
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly FechaEmision { get; set; }

    public decimal SalarioNeto { get; set; }

    public decimal Deducciones { get; set; }

    public virtual Empleado? Empleado { get; set; } = null!;
}
