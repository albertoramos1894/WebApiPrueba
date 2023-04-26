using Api.Business.Interfaces;
using Api.DB.Models;
using Api.Models.Empleados.Request;
using Api.Models.Empleados.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Api.Business
{
    public class EmpleadoBusiness : IEmpleadoBusiness
    {
        public CreateEmpleadoResponse CreateEmpleado(CreateEmpleadoRequest request)
        {
            CreateEmpleadoResponse response;
            try
            {
                //using(var context = new EmpresaContext())
                //{
                //    context.Empleados.AddAsync(new Empleado()
                //    {
                //        NombreS = request.NombreS
                //    });
                //    context.SaveChangesAsync();
                //}
                response= new CreateEmpleadoResponse()
                {
                    Code = (int) HttpStatusCode.OK,
                    Success= true,
                    Message="Se creo el empleado de forma exitosa."
                };
                return response;
            }
            catch(Exception ex)
            {
                response = new CreateEmpleadoResponse()
                {
                    Code= 500,
                    Message= ex.Message,
                    Success= false
                };
                return response;
            }                                     
        }
    }
}
