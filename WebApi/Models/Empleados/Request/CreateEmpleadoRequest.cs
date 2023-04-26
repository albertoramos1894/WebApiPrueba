using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Empleados.Request
{
    public class CreateEmpleadoRequest
    {
        public int IdEmpleado { get; set; }

        public string? Foto { get; set; }

        public string? NombreS { get; set; }

        public string? ApellidoPaterno { get; set; }

        public string? ApellidoMaterno { get; set; }

        public string? PuestoTrabajo { get; set; }

        public decimal? Salario { get; set; }

        public bool? Estatus { get; set; }

        public DateTime? FechaContratación { get; set; }

        public int? IdBeneficiario { get; set; }

        public string? Usuario { get; set; }

        public string? Password { get; set; }
    }
}
