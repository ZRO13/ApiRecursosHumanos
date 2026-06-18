using System;
using System.Collections.Generic;

namespace ApplicationCore.Models;

public partial class Cargo
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public decimal SalarioBase { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
