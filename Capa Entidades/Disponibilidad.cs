using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidades
{
    public class Disponibilidad
    {
        public int id_disponibilidad { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora_inicio { get; set; }
        public TimeSpan hora_fin { get; set; }
    }
}
