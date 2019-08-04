using PracticaFinal.Lib.Services.Dtos;

namespace PracticaFinal.Lib.Services.Interfaces
{
    public interface IRegisterService
    {
        RegisterResponse Register(RegisterRequest registerRequest);
    }
}
