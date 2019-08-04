using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFinal.Lib.Core;
using PracticaFinal.Lib.Services.Dtos;
using PracticaFinal.Lib.Services.Interfaces;

namespace PracticaFinal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService { get; set; }

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<User> Post([FromBody] LoginRequest loginRequest)
        {
            return await Task.Run(() =>
            {
                return _loginService.Authenticate(loginRequest);
            });
        }
    }
}
