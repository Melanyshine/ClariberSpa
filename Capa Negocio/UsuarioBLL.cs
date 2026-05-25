using CapaDatos;
using CapaEntidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class UsuarioBLL
    {
        UsuarioDAL dal = new UsuarioDAL();
        UsuarioDAL objDAL = new UsuarioDAL();

        public int ObtenerSiguienteId()
        {
            return objDAL.ObtenerSiguienteId();
        }

        // =========================
        // LISTAR USUARIOS
        // =========================
        public DataTable Listar()
        {
            return dal.MostrarUsuarios();
        }

        // =========================
        // LISTAR ROLES
        // =========================
        public DataTable ListarRoles()
        {
            return dal.MostrarRoles();
        }

        // =========================
        // GUARDAR
        // =========================
        public void Guardar(Usuario u)
        {
            objDAL.InsertarUsuario(u);
        }

        // =========================
        // ACTUALIZAR
        // =========================
        public void ActualizarUsuario(Usuario u)
        {
            objDAL.ActualizarUsuario(u);
        }

        // =========================
        // ELIMINAR
        // =========================
        public void Eliminar(int id)
        {
            dal.EliminarUsuario(id);
        }

        // =========================
        // LOGIN
        // =========================
        public DataTable Login(string correo, string contrasena)
        {
            return objDAL.Login(correo, contrasena);
        }


    }
}