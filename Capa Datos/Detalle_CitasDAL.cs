using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Detalle_CitasDAL
    {
        public void InsertarDetalle(
            int id_cita,
            int id_servicio,
            decimal precio)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();
            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_detalle_cita_insertar", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cita", id_cita);
            cmd.Parameters.AddWithValue("@id_servicio", id_servicio);
            cmd.Parameters.AddWithValue("@precio", precio);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void EliminarDetalles(int id_cita)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();
            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_detalle_cita_eliminar", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cita", id_cita);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable ObtenerPorCita(int id_cita)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();
            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_detalle_cita_porCita", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cita", id_cita);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }
    }
}