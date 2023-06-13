using Api.Business.Interfaces;
using Api.DB.Models;
using Api.Models.Empleados.Request;
using Api.Models.Empleados.Response;
using Microsoft.EntityFrameworkCore;
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
                using (var context = new EmpresaContext())
                {
                    context.Empleados.Add(new Empleado()
                    {
                        Nombre = request.NombreS
                    });
                    context.SaveChanges();
                }
                response = new CreateEmpleadoResponse()
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

        public GetEmpleadoResponse GetEmpleados()
        {
            GetEmpleadoResponse response = new ();
            response.Result = new ();            
            response.Message = "No se encontraron empleados.";

            try
            {
                using (var context = new EmpresaContext())
                {
                    response.Result.Empleados = context.Empleados.OrderByDescending(x => x.FechaContratación).Take(4).ToList();                                                        
                }


                response.Success = true;
                response.Code = (int)HttpStatusCode.OK;
                if (response.Result.Empleados.Count > 0)
                    response.Message = "Lista de empleados obtenida.";

                return response;
            }
            catch (Exception ex)
            {
                response.Code = 500;
                response.Message = ex.Message;
                response.Success = false;

                return response;
            }
        }
    }
}