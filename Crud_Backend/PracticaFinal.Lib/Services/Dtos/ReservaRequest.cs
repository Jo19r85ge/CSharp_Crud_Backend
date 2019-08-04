using System;

namespace PracticaFinal.Lib.Services.Dtos
{
    public class ReservaRequest
    {
        public Guid CarId { get; set; }
        public Guid MemberId { get; set; }
    }
}
