using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ClientesDAL
    {
        // =========================
        // LISTAR CLIENTES
        // =========================
        public DataTable MostrarClientes()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                using (SqlDataAdapter da = new SqlDataAdapter("SP_ListarClientes", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
        }

        // =========================
        // INSERTAR CLIENTE
        // (SQL maneja la fecha con GETDATE)
        // =========================
        public void InsertarCliente(
            string nombre,
            string apellido,
            string correo,
            string telefono)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_cliente_insertar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 100).Value = apellido;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar, 100).Value = correo;
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = telefono;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =========================
        // ACTUALIZAR CLIENTE
        // =========================
        public void ActualizarCliente(
            int id_cliente,
            string nombre,
            string apellido,
            string correo,
            string telefono)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_cliente_actualizar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = id_cliente;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 100).Value = apellido;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar, 100).Value = correo;
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = telefono;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =========================
        // ELIMINAR CLIENTE
        // =========================
        public void EliminarCliente(int id_cliente)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_cliente_eliminar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = id_cliente;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}