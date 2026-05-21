using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class RolesDAL
    {
        public DataTable MostrarRoles()
        {
            SqlConnection con = Conexion.ObtenerConexion();
            con.Open();

            SqlDataAdapter da =
                new SqlDataAdapter("SP_ListarRoles", con);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();

            return dt;
        }

        public void InsertarRol(int id_rol, string nombre_rol)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_InsertarRol", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_rol", id_rol);
            cmd.Parameters.AddWithValue("@nombre_rol", nombre_rol);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void ActualizarRol(int id_rol, string nombre_rol)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_ActualizarRol", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_rol", id_rol);
            cmd.Parameters.AddWithValue("@nombre_rol", nombre_rol);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EliminarRol(int id_rol)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_EliminarRol", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_rol", id_rol);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}