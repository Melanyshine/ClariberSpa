using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class DisponibilidadBLL
    {
        DisponibilidadDAL dal =
            new DisponibilidadDAL();

        // ==========================
        // LISTAR
        // ==========================
        public DataTable Listar()
        {
            return dal.MostrarDisponibilidad();
        }

        // ==========================
        // LISTAR USUARIOS
        // ==========================
        public DataTable ListarUsuarios()
        {
            return dal.MostrarUsuarios();
        }

        // ==========================
        // GUARDAR
        // ==========================
        public void Guardar(
            Disponibilidad d)
        {
            // INSERTAR
            if (d.id_disponibilidad == 0)
            {
                dal.InsertarDisponibilidad(
                    d.id_usuario,
                    d.fecha,
                    d.hora_inicio,
                    d.hora_fin);
            }

            // ACTUALIZAR
            else
            {
                dal.ActualizarDisponibilidad(
                    d.id_disponibilidad,
                    d.id_usuario,
                    d.fecha,
                    d.hora_inicio,
                    d.hora_fin);
            }
        }

        // ==========================
        // ELIMINAR
        // ==========================
        public void Eliminar(int id)
        {
            dal.EliminarDisponibilidad(id);
        }
    }
}