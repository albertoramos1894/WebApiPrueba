using Api.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Empleados.Response
{
    public class GetEmpleadoResponse : GeneralResponse<ListaEmpleadosResult>
    {
    }

    public class ListaEmpleadosResult
    {
        public List<Empleado> Empleados { get; set; }
    }
}
