using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.DAL
{
    public class Conectar
    {
        public string Conecto()
        {
            var cadena = System.Configuration.ConfigurationManager.AppSettings["CadenaSql"];
            return cadena;
        }

    }
}
