using Newtonsoft.Json;
using PracticaFinal.Lib.Core;
using PracticaFinal.Lib.Models.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaFinal.Lib.Models
{
    public class Car : Entity
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Puerta { get; set; }
        public DateTime? PublicationDate { get; set; }

        [JsonIgnore]
        public ICollection<Reserva>Reservas { get; set; }

    }
}
