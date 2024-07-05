using System.Data.SqlClient;

namespace MVC_Dapper.Data
{
    public class Conexion
    {
        //Campo tipo string privado , solo se usa en la clase Conexion
        private readonly string _connectionString;


        //Constructor que recibira un string y le asignara ese valor a al campo privado _connectionString
        public Conexion(string valor)
        {
            _connectionString = valor;
        }

        //Metodo tipo SqlConnection
        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}
