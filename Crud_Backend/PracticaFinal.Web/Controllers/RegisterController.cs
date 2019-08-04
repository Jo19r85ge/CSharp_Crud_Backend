using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFinal.Lib.Services.Dtos;
using PracticaFinal.Lib.Services.Interfaces;

namespace PracticaFinal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IRegisterService _registerService { get; set; }

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<RegisterResponse> Post([FromBody] RegisterRequest registerRequest)
        {
            return await Task.Run(() =>
            {
                return _registerService.Register(registerRequest);
            });
        }
    }
}

