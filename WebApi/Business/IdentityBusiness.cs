using Api.DB.Models;
using Api.Models.Identity.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Identity.Models;
using Models.Identity.Request;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class IdentityBusiness
    {
        private readonly IConfiguration _configuration;
        public IdentityBusiness(IConfiguration configuration) {
            _configuration = configuration;
        }

        public LoginResponse Login(LoginRequets request)
        {
            Empleado empleado;
            LoginResponse response;
            try
            {
                //Abrimos el canal a la base de datos con EntityFramework
                using (var context = new EmpresaContext())
                {
                    //Buscamos al usuario
                    empleado = context.Empleados.Where(x => x.Usuario == request.UserName && x.Password == request.Password).FirstOrDefault();
                }

                if (empleado != null)
                {
                    var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                    var claims = new[]
                    {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("IdEmpleado",empleado.IdEmpleado.ToString()),
                new Claim("UserName",request.UserName)
            };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var sigIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var jwtToken = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: sigIn
                        );
                    string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                    response = new LoginResponse()
                    {
                        Code = 200,
                        Success = true,
                        Message = "Login exitoso.",
                        Result = token
                    };                    
                }
                else
                {
                    response = new LoginResponse()
                    {
                        Code = 200,
                        Success = false,
                        Message = "El usuario o password son incorrectos favor de verificar."                        
                    };                    
                }
            }
            catch (Exception ex)
            {
                response = new LoginResponse()
                {
                    Success = false,
                    Code = (int)HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                };
                return response;
            }
            return response;
        }
    }
}
