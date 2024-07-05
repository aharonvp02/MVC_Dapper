using Microsoft.AspNetCore.Mvc;
using MVC_Dapper.Data;

namespace MVC_Dapper.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoRepository _iProducto;
        public ProductosController(IProductoRepository iproducto)
        {
            _iProducto = iproducto;
        }
        public IActionResult Index()
        {
           // var producto=_iProducto.ObtenerProductos();
            return View();
        }
        public async Task<IActionResult> listarProductos()
        {
            
            var model = (await _iProducto.ObtenerProductos()).ToList();
            var data = new { data = model };
            return Json(data);
        }

    }
}
