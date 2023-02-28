using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Model
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }

    }
}
