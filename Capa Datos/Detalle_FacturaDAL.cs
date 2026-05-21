using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class Detalle_FacturaDAL
    {
        public DataTable MostrarDetalleFactura()
        {
            SqlConnection con = Conexion.ObtenerConexion();
            con.Open();

            SqlDataAdapter da =
                new SqlDataAdapter("SP_ListarDetalleFactura", con);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();

            return dt;
        }

        public void InsertarDetalleFactura(
            int id_detalle_factura,
            int id_factura,
            int id_servicio,
            string descripcion,
            int cantidad,
            decimal subtotal)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_InsertarDetalleFactura", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_detalle_factura", id_detalle_factura);
            cmd.Parameters.AddWithValue("@id_factura", id_factura);
            cmd.Parameters.AddWithValue("@id_servicio", id_servicio);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@subtotal", subtotal);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void ActualizarDetalleFactura(
            int id_detalle_factura,
            decimal subtotal)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_ActualizarDetalleFactura", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_detalle_factura", id_detalle_factura);
            cmd.Parameters.AddWithValue("@subtotal", subtotal);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EliminarDetalleFactura(int id_detalle_factura)
        {
            SqlConnection con = Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand("SP_EliminarDetalleFactura", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_detalle_factura", id_detalle_factura);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}