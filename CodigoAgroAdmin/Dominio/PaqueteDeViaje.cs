using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestion_de_viajes
{
    public class PaqueteDeViaje
    {
        public int IdPaquete { get; set; }
        public int cdgDestino { get; set; }
        public string NombrePaquete { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioPaquete { get; set; }
        public int Mes {get; set; }
        public int Duracion { get; set; }
        public int TipoTransporte { get; set; }
        public string URLimagen {  get; set; }
        public int Disponibilidad { get; set; }

     
    }
}