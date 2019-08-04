using PracticaFinal.Lib.Core;
using PracticaFinal.Lib.Services.Dtos;

namespace PracticaFinal.Lib.Services.Interfaces
{
    public interface ILoginService
    {
        User Authenticate(LoginRequest loginRequest);
    }
}