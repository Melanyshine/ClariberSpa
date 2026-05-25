using System;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class Detalle_FacturaBLL
    {
        Detalle_FacturaDAL dal =
            new Detalle_FacturaDAL();

        // =========================
        // LISTAR
        // =========================
        public DataTable Listar()
        {
            return dal.MostrarDetalles();
        }

        // =========================
        // GUARDAR
        // =========================
        public void Guardar(Detalle_Factura d)
        {
            if (d.id_factura <= 0)
                throw new Exception(
                    "Debe seleccionar una factura.");

            if (d.id_servicio <= 0)
                throw new Exception(
                    "Debe seleccionar un servicio.");

            if (d.cantidad <= 0)
                throw new Exception(
                    "La cantidad debe ser mayor a 0.");

            dal.InsertarDetalle(
                d.id_factura,
                d.id_servicio,
                d.descripcion,
                d.cantidad,
                d.subtotal);
        }

        // =========================
        // ACTUALIZAR
        // =========================
        public void Actualizar(Detalle_Factura d)
        {
            if (d.id_detalle_factura <= 0)
                throw new Exception(
                    "Selecciona un detalle válido.");

            if (d.cantidad <= 0)
                throw new Exception(
                    "La cantidad debe ser mayor a 0.");

            dal.ActualizarDetalle(
                d.id_detalle_factura,
                d.cantidad);
        }

        // =========================
        // ELIMINAR
        // =========================
        public void Eliminar(int id_detalle_factura)
        {
            if (id_detalle_factura <= 0)
                throw new Exception(
                    "ID de detalle no válido.");

            dal.EliminarDetalle(id_detalle_factura);
        }

        public DataTable ObtenerPorFactura(int idFactura)
        {
            return dal.ObtenerPorFactura(idFactura);
        }
    }
}