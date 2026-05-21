using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidades
{
    public class Citas
    {
        public int id_cita { get; set; }

        public int id_cliente { get; set; }

        public int id_servicio { get; set; }

        public int id_usuario { get; set; }

        public DateTime fecha { get; set; }

        public TimeSpan hora_inicio { get; set; }

        public decimal precio { get; set; }

        public string descripcion { get; set; }

        public string nombre_estado { get; set; }
    }
}