using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class FacturaDAL
    {
        public DataTable MostrarFacturas()
        {
            SqlConnection con = Conexion.ObtenerConexion();
            con.Open();

            SqlDataAdapter da =
                new SqlDataAdapter("SP_ListarFacturas", con);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();

            return dt;
        }

        public void InsertarFactura(
            int id_factura,
            int id_cliente,
            DateTime fecha_factura,
            decimal total,
            string metodo_pago,
            string estado_pago)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_InsertarFactura", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_factura", id_factura);
            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
            cmd.Parameters.AddWithValue("@fecha_factura", fecha_factura);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.Parameters.AddWithValue("@metodo_pago", metodo_pago);
            cmd.Parameters.AddWithValue("@estado_pago", estado_pago);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void ActualizarFactura(
            int id_factura,
            string estado_pago)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_ActualizarFactura", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_factura", id_factura);
            cmd.Parameters.AddWithValue("@estado_pago", estado_pago);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EliminarFactura(int id_factura)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_EliminarFactura", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_factura", id_factura);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}