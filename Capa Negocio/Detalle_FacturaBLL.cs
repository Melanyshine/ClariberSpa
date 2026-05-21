using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocio
{
    public class Detalle_FacturaBLL
    {
        private Detalle_FacturaDAL dal = new Detalle_FacturaDAL();


        public DataTable Listar()
        {
            return dal.MostrarDetalleFactura();
        }


        public void Guardar(Detalle_Factura d)
        {
            if (d.id_detalle_factura == 0)
            {
                dal.InsertarDetalleFactura(
                    d.id_detalle_factura,
                    d.id_factura,
                    d.id_servicio,
                    d.descripcion,
                    d.cantidad,
                    d.subtotal
                );
            }
            else
            {
                dal.ActualizarDetalleFactura(
                    d.id_detalle_factura,
                    d.subtotal
                );
            }
        }


        public void Eliminar(int id)
        {
            dal.EliminarDetalleFactura(id);
        }
    }
}