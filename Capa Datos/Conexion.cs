using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDatos
{

    public class Conexion
    {
        // Cadena de conexión
        private static string cadena =
            "Server=DESKTOP-8GIEJA0\\SQLEXPRESS;Database=ClaribetSpa;Integrated Security=true;";

        // Método para obtener la conexión
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadena);
            return conexion;
        }
    }
}
