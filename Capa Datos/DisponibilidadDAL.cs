// ===============================
// DISPONIBILIDADDAL.cs
// ===============================

using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DisponibilidadDAL
    {
        // ==========================
        // LISTAR
        // ==========================
        public DataTable MostrarDisponibilidad()
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "sp_disponibilidad_listar",
                    con);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            con.Close();

            return dt;
        }

        // ==========================
        // INSERTAR
        // ==========================
        public void InsertarDisponibilidad(
            int id_usuario,
            DateTime fecha,
            TimeSpan hora_inicio,
            TimeSpan hora_fin)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_disponibilidad_insertar",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

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
                "@hora_fin",
                hora_fin);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        // ==========================
        // ACTUALIZAR
        // ==========================
        public void ActualizarDisponibilidad(
    int id_disponibilidad,
    int id_usuario,
    DateTime fecha,
    TimeSpan hora_inicio,
    TimeSpan hora_fin)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_disponibilidad_actualizar",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id_disponibilidad",
                id_disponibilidad);

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
                "@hora_fin",
                hora_fin);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        // ==========================
        // ELIMINAR
        // ==========================
        public void EliminarDisponibilidad(
            int id_disponibilidad)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_disponibilidad_eliminar",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id_disponibilidad",
                id_disponibilidad);

            cmd.ExecuteNonQuery();

            con.Close();

        }

            // ==================================
            // MOSTRAR USUARIOS
            // ==================================
public DataTable MostrarUsuarios()
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT id_usuario, nombre + ' ' + apellido AS Usuario FROM Usuario",
                    con);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            con.Close();

            return dt;
        }
    }
}
