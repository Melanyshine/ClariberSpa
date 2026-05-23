using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Detalle_Factura
    {
        public int id_detalle_factura { get; set; }
        public int id_factura { get; set; }
        public int id_servicio { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
    }
}