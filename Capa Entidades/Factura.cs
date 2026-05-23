using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Factura
    {
        public int id_factura { get; set; }
        public int id_cliente { get; set; }
        public string cliente { get; set; }
        public DateTime fecha_factura { get; set; }
        public decimal total { get; set; }
        public string metodo_pago { get; set; }
        public string estado_pago { get; set; }
    }
}