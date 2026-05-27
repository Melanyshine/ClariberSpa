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
            SqlConnection con = Conexion.ObtenerConexion();
            con.Open();

            SqlDataAdapter daD = new SqlDataAdapter(
                new SqlCommand("sp_detalle_cita_porCita", con)
                {
                    CommandType = CommandType.StoredProcedure
                });
            daD.SelectCommand.Parameters.AddWithValue("@id_cita", id_cita);
            DataTable dtCita = new DataTable();
            daD.Fill(dtCita);

            SqlDataAdapter daS = new SqlDataAdapter(
                new SqlCommand("sp_servicio_listar", con)
                {
                    CommandType = CommandType.StoredProcedure
                });
            DataTable dtTodos = new DataTable();
            daS.Fill(dtTodos);
            con.Close();

            DataTable dt = new DataTable();
            dt.Columns.Add("id_servicio", typeof(int));
            dt.Columns.Add("nombre_servicio", typeof(string));
            dt.Columns.Add("precio", typeof(decimal));
            dt.Columns.Add("en_cita", typeof(bool));

            foreach (DataRow s in dtTodos.Rows)
            {
                int id = Convert.ToInt32(s["id_servicio"]);
                DataRow[] match = dtCita.Select("id_servicio = " + id);
                bool enCita = match.Length > 0;
                decimal precio = enCita ? Convert.ToDecimal(match[0]["precio"]) : Convert.ToDecimal(s["precio"]);
                dt.Rows.Add(id, s["nombre_servicio"], precio, enCita);
            }
            return dt;
        }
    }
}