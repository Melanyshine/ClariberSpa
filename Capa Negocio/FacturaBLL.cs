using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocio
{
    public class FacturaBLL
    {
        private FacturaDAL dal = new FacturaDAL();


        public DataTable Listar()
        {
            return dal.MostrarFacturas();
        }


        public void Guardar(Factura f)
        {
            if (f.id_factura == 0)
            {
                dal.InsertarFactura(
                    f.id_factura,
                    f.id_cliente,
                    f.fecha_factura,
                    f.total,
                    f.metodo_pago,
                    f.estado_pago
                );
            }
            else
            {
                dal.ActualizarFactura(
                    f.id_factura,
                    f.estado_pago
                );
            }
        }


        public void Eliminar(int id)
        {
            dal.EliminarFactura(id);
        }
    }
}