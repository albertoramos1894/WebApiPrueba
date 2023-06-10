using Api.Models.Empleados.Request;
using Api.Models.Empleados.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Business.Interfaces
{
    public interface IEmpleadoBusiness
    {
        CreateEmpleadoResponse CreateEmpleado(CreateEmpleadoRequest request);
        GetEmpleadoResponse GetEmpleados();
    }
}
