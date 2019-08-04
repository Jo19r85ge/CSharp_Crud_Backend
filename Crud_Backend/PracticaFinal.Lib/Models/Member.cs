using Newtonsoft.Json;
using PracticaFinal.Lib.Core;
using PracticaFinal.Lib.Models.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticaFinal.Lib.Models
{
    public class Member : User
    {
        [JsonIgnore]
        public ICollection<Reserva> Reservas { get; set; }

        public List<Guid> ReservasIds
        {
            get
            {
                return Reservas == null ? new List<Guid>() : Reservas.Select(x => x.Id).ToList();
            }
        }
    }
}
