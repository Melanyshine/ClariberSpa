using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class FacturaDAL
    {
        // =========================
        // LISTAR
        // =========================
        public DataTable MostrarFacturas()
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "sp_factura_listar",
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
        public int InsertarFactura(int id_cliente, DateTime fecha_factura, decimal total, string metodo_pago, string estado_pago)
        {
            SqlConnection con = Conexion.ObtenerConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_factura_insertar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
            cmd.Parameters.AddWithValue("@fecha_factura", fecha_factura);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.Parameters.AddWithValue("@metodo_pago", metodo_pago);
            cmd.Parameters.AddWithValue("@estado_pago", estado_pago);
            int idNuevo = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return idNuevo;
        }

        // =========================
        // ACTUALIZAR
        // =========================
        public void ActualizarFactura(
     int idFactura,
     string estado)
        {
            using (SqlConnection con =
                Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd =
                    new SqlCommand(
                        @"UPDATE Factura
                  SET estado_pago = @estado
                  WHERE id_factura = @id",
                        con);

                cmd.Parameters.AddWithValue(
                    "@estado",
                    estado);

                cmd.Parameters.AddWithValue(
                    "@id",
                    idFactura);

                cmd.ExecuteNonQuery();
            }
        }

        // =========================
        // ELIMINAR
        // =========================
        public void EliminarFactura(
            int id_factura)
        {
            SqlConnection con =
                Conexion.ObtenerConexion();

            con.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_factura_eliminar",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id_factura",
                id_factura);

            cmd.ExecuteNonQuery();

            con.Close();
        }


    }
}