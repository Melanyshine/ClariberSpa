using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class Historial_CitaDAL
    {
        // =========================
        // MOSTRAR HISTORIAL
        // =========================

        public DataTable MostrarHistorial()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con =
                Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd =
                    new SqlCommand("sp_historial_listar", con))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    SqlDataAdapter da =
                        new SqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }

            return dt;
        }

        // =========================
        // INSERTAR
        // =========================

        public void InsertarHistorial(
            Historial_Cita h)
        {
            using (SqlConnection con =
                Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd =
                    new SqlCommand("SP_InsertarHistorial", con))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@id_historial",
                        h.id_historial);

                    cmd.Parameters.AddWithValue(
                        "@id_cita",
                        h.id_cita);

                    cmd.Parameters.AddWithValue(
                        "@nombre_estado",
                        h.nombre_estado);

                    cmd.Parameters.AddWithValue(
                        "@fecha",
                        h.fecha);

                    cmd.Parameters.AddWithValue(
                        "@accion",
                        h.accion);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =========================
        // ACTUALIZAR
        // =========================

        public void ActualizarHistorial(
            Historial_Cita h)
        {
            using (SqlConnection con =
                Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd =
                    new SqlCommand("SP_ActualizarHistorial", con))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@id_historial",
                        h.id_historial);

                    cmd.Parameters.AddWithValue(
                        "@accion",
                        h.accion);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =========================
        // ELIMINAR
        // =========================

        public void EliminarHistorial(
            int id_historial)
        {
            using (SqlConnection con =
                Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd =
                    new SqlCommand("SP_EliminarHistorial", con))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@id_historial",
                        id_historial);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}