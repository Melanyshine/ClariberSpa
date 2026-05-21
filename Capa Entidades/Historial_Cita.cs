using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidades
{
    public class Historial_Cita
    {
        public int id_historial { get; set; }
        public int id_cita { get; set; }
        public string nombre_estado { get; set; }
        public DateTime fecha { get; set; }
        public string accion { get; set; }
    }
}
