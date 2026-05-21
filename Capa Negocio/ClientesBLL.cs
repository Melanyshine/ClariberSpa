using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocio
{
    public class ClientesBLL
    {
        private ClientesDAL dal = new ClientesDAL();

        // LISTAR CLIENTES
        public DataTable Listar()
        {
            return dal.MostrarClientes();
        }

        // GUARDAR CLIENTE
        public void Guardar(Clientes c)
        {
            if (c == null)
                return;

            if (c.id_cliente == 0)
            {
                // INSERT (SQL maneja la fecha)
                dal.InsertarCliente(
                    c.nombre,
                    c.apellido,
                    c.correo,
                    c.telefono
                );
            }
            else
            {
                // UPDATE
                dal.ActualizarCliente(
                    c.id_cliente,
                    c.nombre,
                    c.apellido,
                    c.correo,
                    c.telefono
                );
            }
        }

        // ELIMINAR CLIENTE
        public void Eliminar(int id)
        {
            if (id <= 0)
                return;

            dal.EliminarCliente(id);
        }
    }
}