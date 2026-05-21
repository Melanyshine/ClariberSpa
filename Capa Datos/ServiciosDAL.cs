using CapaEntidades;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ServiciosDAL
    {
        public DataTable MostrarServicios()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_ListarServicios", con);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        // =====================================
        // INSERTAR
        // =====================================
        public void InsertarServicio(Servicios s)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_InsertarServicio", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre_servicio", s.nombre_servicio);

                // CATEGORIA
                cmd.Parameters.AddWithValue("@categoria", s.categoria);

                cmd.Parameters.AddWithValue("@precio", s.precio);

                cmd.Parameters.AddWithValue("@duracion_minutos", s.duracion_minutos);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        // =====================================
        // ACTUALIZAR
        // =====================================
        public void ActualizarServicio(Servicios s)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_ActualizarServicio", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_servicio", s.id_servicio);

                cmd.Parameters.AddWithValue("@nombre_servicio", s.nombre_servicio);

                // CATEGORIA
                cmd.Parameters.AddWithValue("@categoria", s.categoria);

                cmd.Parameters.AddWithValue("@precio", s.precio);

                cmd.Parameters.AddWithValue("@duracion_minutos", s.duracion_minutos);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        // =====================================
        // ELIMINAR
        // =====================================
        public void EliminarServicio(int id)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarServicio", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_servicio", id);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}