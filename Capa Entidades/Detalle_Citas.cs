using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaEntidades
{
    public class Detalle_Citas
    {
        public int id_detalle_cita { get; set; }

        public int id_cita { get; set; }

        public int id_servicio { get; set; }

        public decimal precio { get; set; }
    }
}