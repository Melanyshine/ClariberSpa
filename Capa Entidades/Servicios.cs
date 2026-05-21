using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidades
{

    public class Servicios
    {
        public int id_servicio { get; set; }
        public string nombre_servicio { get; set; }
        public decimal precio { get; set; }
        public int duracion_minutos { get; set; }
    }
}