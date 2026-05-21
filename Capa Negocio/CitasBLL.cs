using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocio
{
    public class CitasBLL
    {
        private CitasDAL dal =
            new CitasDAL();

        public DataTable Listar()
        {
            return dal.MostrarCitas();
        }

        public void Guardar(Citas c)
        {
            dal.InsertarCita(
                c.id_cliente,
                c.id_servicio,
                c.id_usuario,
                c.fecha,
                c.hora_inicio,
                c.precio,
                c.descripcion,
                c.nombre_estado
            );
        }

        public void Actualizar(Citas c)
        {
            dal.ActualizarCita(
                c.id_cita,
                c.id_cliente,
                c.id_servicio,
                c.id_usuario,
                c.fecha,
                c.hora_inicio,
                c.precio,
                c.descripcion,
                c.nombre_estado
            );
        }

        public void Eliminar(
            int id)
        {
            dal.EliminarCita(id);
        }

    }
}