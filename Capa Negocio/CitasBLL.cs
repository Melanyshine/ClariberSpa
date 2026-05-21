using CapaDatos;
using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class CitasBLL
    {
        private CitasDAL dal =
            new CitasDAL();

        private Detalle_CitasDAL detalleDAL =
            new Detalle_CitasDAL();

        public DataTable Listar()
        {
            return dal.MostrarCitas();
        }

        // =========================
        // GUARDAR
        // =========================
        public void Guardar(
            Citas c,
            CheckedListBox.CheckedItemCollection servicios)
        {
            int idCita =
                dal.InsertarCita(
                    c.id_cliente,
                    c.id_usuario,
                    c.fecha,
                    c.hora_inicio,
                    c.precio,
                    c.descripcion,
                    c.nombre_estado
                );

            foreach (var item in servicios)
            {
                DataRowView fila =
                    (DataRowView)item;

                detalleDAL.InsertarDetalle(
                    idCita,
                    Convert.ToInt32(
                        fila["id_servicio"]),
                    Convert.ToDecimal(
                        fila["precio"])
                );
            }
        }

        // =========================
        // ACTUALIZAR
        // =========================
        public void Actualizar(
            Citas c,
            CheckedListBox.CheckedItemCollection servicios)
        {
            dal.ActualizarCita(
                c.id_cita,
                c.id_cliente,
                c.id_usuario,
                c.fecha,
                c.hora_inicio,
                c.precio,
                c.descripcion,
                c.nombre_estado
            );

            detalleDAL.EliminarDetalles(
                c.id_cita);

            foreach (var item in servicios)
            {
                DataRowView fila =
                    (DataRowView)item;

                detalleDAL.InsertarDetalle(
                    c.id_cita,
                    Convert.ToInt32(
                        fila["id_servicio"]),
                    Convert.ToDecimal(
                        fila["precio"])
                );
            }
        }

        // =========================
        // ELIMINAR
        // =========================
        public void Eliminar(int id)
        {
            dal.EliminarCita(id);
        }
    }
}