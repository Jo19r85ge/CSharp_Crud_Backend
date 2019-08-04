using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaFinal.Lib.Services.Dtos
{
    public class RegisterRequest
    {
        public string Name { get; set; }

        public string Surname1 { get; set; }

        public string Surname2 { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
