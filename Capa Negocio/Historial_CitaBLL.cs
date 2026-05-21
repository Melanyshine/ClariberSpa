using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocio
{
    public class Historial_CitaBLL
    {
        private Historial_CitaDAL dal =
            new Historial_CitaDAL();

        public DataTable Listar()
        {
            return dal.MostrarHistorial();
        }

        public void Insertar(Historial_Cita h)
        {
            dal.InsertarHistorial(h);
        }

        public void Actualizar(Historial_Cita h)
        {
            dal.ActualizarHistorial(h);
        }

        public void Eliminar(int id)
        {
            dal.EliminarHistorial(id);
        }
    }
}