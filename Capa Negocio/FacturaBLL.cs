using System;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class FacturaBLL
    {
        FacturaDAL dal = new FacturaDAL();


        public DataTable Listar()
        {
            return dal.MostrarFacturas();
        }

        public int Guardar(Factura f)
        {
            if (f.id_cliente <= 0)
                throw new Exception("Debe seleccionar un cliente.");
            if (string.IsNullOrWhiteSpace(f.metodo_pago))
                throw new Exception("El método de pago es obligatorio.");
            if (string.IsNullOrWhiteSpace(f.estado_pago))
                throw new Exception("El estado de pago es obligatorio.");
            return dal.InsertarFactura(f.id_cliente, f.fecha_factura, f.total, f.metodo_pago, f.estado_pago);
        }
        public void Actualizar(Factura f)
        {
            if (f.id_factura <= 0)
                throw new Exception(
                    "Selecciona una factura válida.");

            if (string.IsNullOrWhiteSpace(f.estado_pago))
                throw new Exception(
                    "El estado de pago es obligatorio.");

            dal.ActualizarFactura(
                f.id_factura,
                f.estado_pago);
        }


        public void Eliminar(int id_factura)
        {
            if (id_factura <= 0)
                throw new Exception(
                    "ID de factura no válido.");

            dal.EliminarFactura(id_factura);
        }

        public void ActualizarEstado(
            int idFactura,
            string estado)
        {
            dal.ActualizarFactura(
                idFactura,
                estado);
        }
    }

}