// =========================
// DETALLE CITA BLL
// =========================

using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DetalleCitas_BLL
    {
        private Detalle_CitasDAL dal =
            new Detalle_CitasDAL();

        public void Insertar(
            int id_cita,
            int id_servicio,
            decimal precio)
        {
            dal.InsertarDetalle(
                id_cita,
                id_servicio,
                precio);
        }

        public DataTable ObtenerPorCita(int id_cita)
        {
            return dal.ObtenerPorCita(id_cita);
        }
    }
}