using Api.Business;
using Api.Business.Interfaces;
using Api.Models;
using Api.Models.Empleados.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoBusiness _empleadoBusiness;
        public EmpleadoController(IEmpleadoBusiness empleadoBusiness)
        {
            _empleadoBusiness = empleadoBusiness;
        }

        [HttpPost]        
        [Authorize]
        public async Task<IActionResult> Create(CreateEmpleadoRequest request)
        {
            try
            {                
                var result = _empleadoBusiness.CreateEmpleado(request);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(new GeneralResponse<Object>() { Code = (int) HttpStatusCode.BadRequest, Message = "Ocurrio un error inesperado", Success = false });
            }
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {                
                var result = _empleadoBusiness.GetEmpleados();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResponse<Object>() { Code = (int)HttpStatusCode.BadRequest, Message = "Ocurrio un error inesperado", Success = false });
            }
        }
    }
}
