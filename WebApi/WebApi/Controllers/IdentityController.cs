using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Identity.Request;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IdentityBusiness _business;

        public IdentityController(IConfiguration configuration) { 
            _configuration = configuration;
            _business = new IdentityBusiness(_configuration);            
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequets request)
        {
            var result = _business.Login(request);

            return StatusCode(result.Code,result);

        }
    }
}
