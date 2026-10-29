
using GestionDeProductosAPI.DTOs;
using GestionDeProductosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosAPI.Controllers
{
    [ApiController]                                                             //Activa la validación automática de los DTOs con Data Annotations. Si el cuerpo del POST o PUT no cumple las validaciones, ASP.NET Core responde normalmente con 400 Bad Request sin ejecutar la acción.
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            List<ProductoDto> productos = _productoService.ObtenerTodos();

            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            ProductoDto? producto = _productoService.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound(new { mensaje = "Producto no encontrado." });
            }

            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] CreateProductoDto productoDto)
        {
            ProductoDto productoCreado = _productoService.Crear(productoDto);

            return CreatedAtAction(                                                         //CreatedAtAction() devuelve 201 Created e incluye una referencia al endpoint para consultar el producto recién creado.
                nameof(ObtenerPorId),
                new { id = productoCreado.Id },
                productoCreado
            );
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] CreateProductoDto productoDto)
        {
            bool actualizado = _productoService.Actualizar(id, productoDto);

            if (!actualizado)
            {
                return NotFound(new { mensaje = "Producto no encontrado." });
            }

            return NoContent();                                                                 //NoContent() devuelve 204, indicando que la operación se realizó correctamente sin necesidad de devolver un cuerpo.
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            bool eliminado = _productoService.Eliminar(id);

            if (!eliminado)
            {
                return NotFound(new { mensaje = "Producto no encontrado." });
            }

            return NoContent();
        }
    }
}
