using MVC_Dapper.Models;

namespace MVC_Dapper.Data
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerProductos();
        Producto ObtenerProductoPorId(int id);

        void InsertarProducto(Producto obj);
        void ActualizarProducto(Producto obj);
        void EliminarProducto(int id);
    }
}
