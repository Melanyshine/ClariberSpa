using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class ClientesDAL
    {
        public DataTable MostrarClientes()
        {
            SqlConnection con = Conexion.ObtenerConexion();
            con.Open();

            SqlDataAdapter da =
                new SqlDataAdapter("SP_ListarClientes", con);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();

            return dt;
        }

        public void InsertarCliente(
            int id_cliente,
            string nombre,
            string apellido,
            string correo,
            string telefono,
            DateTime fecha_registro)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_InsertarCliente", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@fecha_registro", fecha_registro);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void ActualizarCliente(
            int id_cliente,
            string nombre,
            string apellido,
            string correo,
            string telefono)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_ActualizarCliente", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@telefono", telefono);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EliminarCliente(int id_cliente)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_EliminarCliente", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}