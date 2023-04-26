using System;
using System.Collections.Generic;

namespace Api.DB.Models;

public partial class Beneficiario
{
    public int IdBeneficiario { get; set; }

    public string? NombreS { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public int? IdEmpleado { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Empleado IdBeneficiarioNavigation { get; set; } = null!;
}
