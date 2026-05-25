using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class UsuarioDAL
    {
        // ====================================
        // OBTENER SIGUIENTE ID
        // ====================================
        public int ObtenerSiguienteId()
        {
            int id = 1;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT ISNULL(MAX(id_usuario),0) + 1 FROM Usuario",
                    con);

                object result = cmd.ExecuteScalar();

                if (result != null)
                    id = Convert.ToInt32(result);
            }

            return id;
        }

        // ====================================
        // LISTAR USUARIOS
        // ====================================
        public DataTable MostrarUsuarios()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "sp_usuario_listar",
                    con);

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ====================================
        // MOSTRAR ROLES
        // ====================================
        public DataTable MostrarRoles()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "SELECT * FROM Roles",
                        con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ====================================
        // INSERTAR USUARIO
        // ====================================
        public void InsertarUsuario(Usuario u)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "sp_usuario_insertar",
                    con);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@id_rol",
                    u.id_rol);

                cmd.Parameters.AddWithValue(
                    "@nombre",
                    u.nombre);

                cmd.Parameters.AddWithValue(
                    "@apellido",
                    u.apellido);

                cmd.Parameters.AddWithValue(
                    "@correo",
                    u.correo);

                cmd.Parameters.AddWithValue(
                    "@telefono",
                    u.telefono);

                cmd.Parameters.AddWithValue(
                    "@nombre_usuario",
                    u.nombre_usuario);

                cmd.Parameters.AddWithValue(
                    "@contrasena",
                    u.contraseña);

                cmd.Parameters.AddWithValue(
                    "@fecha_registro",
                    u.fecha_registro);

                cmd.ExecuteNonQuery();
            }
        }

        // ====================================
        // ACTUALIZAR USUARIO
        // ====================================
        public void ActualizarUsuario(Usuario u)
        {
            SqlConnection con = Conexion.ObtenerConexion();
            con.Open();

            SqlCommand cmd = new SqlCommand(
                "sp_usuario_actualizar",
                con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_usuario", u.id_usuario);
            cmd.Parameters.AddWithValue("@id_rol", u.id_rol);
            cmd.Parameters.AddWithValue("@nombre", u.nombre);
            cmd.Parameters.AddWithValue("@apellido", u.apellido);
            cmd.Parameters.AddWithValue("@correo", u.correo);
            cmd.Parameters.AddWithValue("@telefono", u.telefono);
            cmd.Parameters.AddWithValue("@nombre_usuario", u.nombre_usuario);
            cmd.Parameters.AddWithValue("@contrasena", u.contraseña);
            cmd.Parameters.AddWithValue("@fecha_registro", u.fecha_registro);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        // ====================================
        // ELIMINAR USUARIO
        // ====================================
        public void EliminarUsuario(int id)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "sp_usuario_eliminar",
                    con);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@id_usuario",
                    id);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Login(string correo, string contrasena)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contraseña", contrasena);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}