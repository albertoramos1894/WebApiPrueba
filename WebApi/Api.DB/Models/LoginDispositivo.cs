using System;
using System.Collections.Generic;

namespace Api.DB.Models;

public partial class LoginDispositivo
{
    public int IdLogin { get; set; }

    public int? IdDispositivo { get; set; }

    public int? IdEmpleado { get; set; }

    public bool? Status { get; set; }
}
