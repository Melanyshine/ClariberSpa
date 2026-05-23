using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class CitasDAL
    {
        public DataTable MostrarCitas()
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SP_ListarCitas",
                    con);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            con.Close();

            return dt;
        }

 

        public int InsertarCita(
            int id_cliente,
            int id_usuario,
            DateTime fecha,
            TimeSpan hora_inicio,
            decimal precio,
            string descripcion,
            string nombre_estado)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_cita_insertar",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id_cliente",
                id_cliente);

            cmd.Parameters.AddWithValue(
                "@id_usuario",
                id_usuario);

            cmd.Parameters.AddWithValue(
                "@fecha",
                fecha);

            cmd.Parameters.AddWithValue(
                "@hora_inicio",
                hora_inicio);

            cmd.Parameters.AddWithValue(
                "@precio",
                precio);

            cmd.Parameters.AddWithValue(
                "@descripcion",
                descripcion);

            cmd.Parameters.AddWithValue(
                "@nombre_estado",
                nombre_estado);

            int idCita =
                Convert.ToInt32(
                cmd.ExecuteScalar());

            con.Close();

            return idCita;
        }

        // =========================
        // ACTUALIZAR
        // =========================
        // =========================
        // ACTUALIZAR
        // =========================
        public void ActualizarCita(
       int id_cita,
       int id_cliente,
       int id_usuario,
       DateTime fecha,
       TimeSpan hora_inicio,
       decimal precio,
       string descripcion,
       string nombre_estado)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_cita_actualizar",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id_cita",
                id_cita);

            cmd.Parameters.AddWithValue(
                "@id_cliente",
                id_cliente);

            cmd.Parameters.AddWithValue(
                "@id_usuario",
                id_usuario);

            cmd.Parameters.AddWithValue(
                "@fecha",
                fecha);

            cmd.Parameters.AddWithValue(
                "@hora_inicio",
                hora_inicio);

            cmd.Parameters.AddWithValue(
                "@precio",
                precio);

            cmd.Parameters.AddWithValue(
                "@descripcion",
                descripcion);

            cmd.Parameters.AddWithValue(
                "@nombre_estado",
                nombre_estado);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        // =========================
        // ELIMINAR
        // =========================
        public void EliminarCita(
            int id_cita)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_cita_eliminar",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id_cita",
                id_cita);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        // =========================
        // OBTENER CITA POR ID
        // =========================
        public DataTable ObtenerCitaPorId(int id_cita)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "SP_ListarCitas",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            con.Close();

            // Filtra solo la cita que necesitamos
            DataTable resultado = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(
                    row["id_cita"]) == id_cita)
                {
                    resultado.ImportRow(row);
                    break;
                }
            }

            return resultado;
        }
    }
}