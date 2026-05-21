using CapaDatos;
using CapaEntidades;
using System.Collections.Generic;
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
            if (c.id_cliente == 0)
            {
                dal.InsertarCliente(
                    c.id_cliente,
                    c.nombre,
                    c.apellido,
                    c.correo,
                    c.telefono,
                    c.fecha_registro
                );
            }
            else
            {
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
            dal.EliminarCliente(id);
        }
    }
}