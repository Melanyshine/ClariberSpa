using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocio
{
    public class RolesBLL
    {
        private RolesDAL dal = new RolesDAL();


        public DataTable Listar()
        {
            return dal.MostrarRoles();
        }


        public void Guardar(Roles r)
        {
            if (r.id_rol == 0)
            {
                dal.InsertarRol(
                    r.id_rol,
                    r.nombre_rol
                );
            }
            else
            {
                dal.ActualizarRol(
                    r.id_rol,
                    r.nombre_rol
                );
            }
        }


        public void Eliminar(int id)
        {
            dal.EliminarRol(id);
        }
    }
}