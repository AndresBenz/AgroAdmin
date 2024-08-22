using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestion_de_viajes
{
    public class Hotel
    {
        public int IdHotel { get; set; }
        public string NombreHotel { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public int cdgDestino { get; set; }
        public string URLimagen {  get; set; }
    }
}