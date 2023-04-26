using System;
using System.Collections.Generic;

namespace Api.DB.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Foto { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? PuestoTrabajo { get; set; }

    public decimal? Salario { get; set; }

    public bool? Estatus { get; set; }

    public DateTime? FechaContratación { get; set; }

    public int? IdBeneficiario { get; set; }

    public string? Usuario { get; set; }

    public string? Password { get; set; }

    public virtual Beneficiario? Beneficiario { get; set; }

    public virtual Beneficiario? IdBeneficiarioNavigation { get; set; }
}
