using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class Detalle_FacturaDAL
    {
        // =========================
        // LISTAR
        // =========================
        public DataTable MostrarDetalles()
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "sp_detalle_factura_listar",
                    con);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            con.Close();

            return dt;
        }

        // =========================
        // INSERTAR
        // =========================
        public void InsertarDetalle(
            int id_factura,
            int id_servicio,
            string descripcion,
            int cantidad,
            decimal subtotal)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_detalle_factura_insertar",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id_factura",
                id_factura);

            cmd.Parameters.AddWithValue(
                "@id_servicio",
                id_servicio);

            cmd.Parameters.AddWithValue(
                "@descripcion",
                descripcion);

            cmd.Parameters.AddWithValue(
                "@cantidad",
                cantidad);

            cmd.Parameters.AddWithValue(
                "@subtotal",
                subtotal);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        // =========================
        // ACTUALIZAR
        // =========================
        public void ActualizarDetalle(
            int id_detalle_factura,
            int cantidad)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_detalle_factura_actualizar",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id_detalle_factura",
                id_detalle_factura);

            cmd.Parameters.AddWithValue(
                "@cantidad",
                cantidad);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        // =========================
        // ELIMINAR
        // =========================
        public void EliminarDetalle(
            int id_detalle_factura)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_detalle_factura_eliminar",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id_detalle_factura",
                id_detalle_factura);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}