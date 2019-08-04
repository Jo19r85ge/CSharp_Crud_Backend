using PracticaFinal.Lib.Core;
using System;


namespace PracticaFinal.Lib.Models.Relations
{
    public class Reserva : Entity
    {
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public DateTime ReservaOn { get; set; }
        public int DaysReservado { get; set; }

        public string CarComposedMarca
        {
            get
            {
                return Car.Marca + ", " + Car.Modelo;
            }
        }
    }
}
