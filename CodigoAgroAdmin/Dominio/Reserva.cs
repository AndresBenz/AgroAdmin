using Gestion_de_viajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int DNIUsuario { get; set; }
        public int estado { get; set; } // Estado de la reserva 1 aceptada 0 cancelada
        public int idHotel { get; set; }
        public int IdPaquete { get; set; } // toma el objeto de paquete de viaje
        public decimal Precio { get; set; }
        public DateTime FechaInicio { get; set; }
        
       

    }

    public class ReservaFinal
    {
        public int IdReserva { get; set; }
        public int DNIUsuario { get; set; }
        public int estado { get; set; } // Estado de la reserva 1 aceptada 0 cancelada
        public int idHotel { get; set; }
        public string nombreHotel { get; set; } //nuevo
        public int IdPaquete { get; set; } // toma el objeto de paquete de viaje
        public string NombrePaquete { get; set; } //nuevo
        public decimal Precio { get; set; }
        public DateTime FechaInicio { get; set; }
        public int cdgdestino { get; set; }



    }
}
