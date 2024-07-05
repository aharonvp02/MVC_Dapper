using Dapper;
using MVC_Dapper.Models;
using System.Data;

namespace MVC_Dapper.Data
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly Conexion _conexion;

        public ProductoRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

       public void ActualizarProducto(Producto obj)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@Id", obj.Id, DbType.Int32);
                    parametros.Add("@Nombre", obj.Nombre, DbType.String);
                    parametros.Add("@Precio", obj.Precio, DbType.Decimal);
                    conexion.Execute("ActualizarProducto", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ActualizarProducto: " + ex.Message + ", StackTrace: " + ex.StackTrace);
                
            }

           

        }

       public void EliminarProducto(int id)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@Id", id, DbType.Int32);
                   
                    conexion.Execute("EliminarProducto", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en EliminarProducto: " + ex.Message + ", StackTrace: " + ex.StackTrace);

            }
        }

        public void InsertarProducto(Producto obj)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {
                    var parametros = new DynamicParameters();
                   
                    parametros.Add("@Nombre", obj.Nombre, DbType.String);
                    parametros.Add("@Precio", obj.Precio, DbType.Decimal);
                    conexion.Execute("InsertarProducto", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en InsertarProducto: " + ex.Message + ", StackTrace: " + ex.StackTrace);

            }
        }

       public Producto ObtenerProductoPorId(int id)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@Id", id, DbType.Int32);              
                    return conexion.QueryFirstOrDefault<Producto>("ObtenerProducto", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ActualizarProducto: " + ex.Message + ", StackTrace: " + ex.StackTrace);
                return null;
            }
        }

      //public  IEnumerable<Producto> ObtenerProductos()
      //  {
      //      try
      //      {
      //          using (var conexion = _conexion.ObtenerConexion())
      //          {
      //              //var parametros = new DynamicParameters();
      //              //parametros.Add("@Id", id, DbType.Int32);
      //              return conexion.Query<Producto>("ObtenerProductos",  commandType: CommandType.StoredProcedure).ToList();
      //          }
      //      }
      //      catch (Exception ex)
      //      {
      //          Console.WriteLine("Error en ActualizarProducto: " + ex.Message + ", StackTrace: " + ex.StackTrace);
      //          return null;
      //      }
      //  }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {
                    //var parametros = new DynamicParameters();
                    //parametros.Add("@Id", id, DbType.Int32);
                    return await conexion.QueryAsync<Producto>("ObtenerProductos", commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ActualizarProducto: " + ex.Message + ", StackTrace: " + ex.StackTrace);
                return null;
            }
        }
    }
}
