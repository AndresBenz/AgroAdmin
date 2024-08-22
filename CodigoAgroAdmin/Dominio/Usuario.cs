using System.Collections.Generic;

namespace Dominio
{

    public enum TipoUsuario
    {
        Normal = 1,
        Admin = 2,
    }
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public int DNI { get; set; }
        public string NombreUsuario { get; set; }
        public string CorreoElectronico { get; set; }

    
        public string Telefono { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public Usuario() {
            TipoUsuario = TipoUsuario.Normal;
        }
        public Usuario(string user, int pass, bool admin)
        {
            CorreoElectronico = user;
            DNI = pass;
            TipoUsuario = admin ? TipoUsuario.Admin : TipoUsuario.Normal;

        }
    }
}
