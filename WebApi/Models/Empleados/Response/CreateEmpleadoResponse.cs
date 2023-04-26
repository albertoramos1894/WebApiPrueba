using Api.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Empleados.Response
{
    public class CreateEmpleadoResponse : GeneralResponse<EmpleadoResult>
    {
    }
    public class EmpleadoResult
    {
        public Empleado empleado { get; set; }
    }
}
