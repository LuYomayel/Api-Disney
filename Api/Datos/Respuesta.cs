using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Datos
{
    public class Respuesta
    {
        public string status { get; set; }
        public bool exito { get; set; }
        public string message { get; set; }
        public dynamic result { get; set; }

        public Respuesta()
        {
            status = "success";
        }
    }
}
