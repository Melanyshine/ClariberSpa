using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidades
{
    public class Roles
    {
        public int id_rol { get; set; }
        public string nombre_rol { get; set; }

        public static int IdRolActivo { get; set; }
        public static string NombreUsuarioActivo { get; set; }
    }
}
