using System;
using System.Collections.Generic;

namespace ApplicationCore.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public int DepartamentoId { get; set; }

    public int CargoId { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual Departamento Departamento { get; set; } = null!;

    public virtual ICollection<EvaluacionDesempeno> EvaluacionDesempenos { get; set; } = new List<EvaluacionDesempeno>();

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
