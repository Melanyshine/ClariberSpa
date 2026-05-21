using CapaDatos;
using CapaEntidades;
using System;
using System.Data;

namespace CapaNegocio
{
    public class ServiciosBLL
    {
        ServiciosDAL dal = new ServiciosDAL();

        public DataTable Listar()
        {
            return dal.MostrarServicios();
        }

        public void Guardar(Servicios s)
        {
            Validar(s);

            if (s.id_servicio == 0)
                dal.InsertarServicio(s);
            else
                dal.ActualizarServicio(s);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("ID inválido");

            dal.EliminarServicio(id);
        }

        private void Validar(Servicios s)
        {
            if (s == null)
                throw new Exception("Servicio vacío");

            if (string.IsNullOrWhiteSpace(s.nombre_servicio))
                throw new Exception("Nombre requerido");

            if (s.precio <= 0)
                throw new Exception("Precio inválido");

            if (s.duracion_minutos <= 0)
                throw new Exception("Duración inválida");
        }
    }
}