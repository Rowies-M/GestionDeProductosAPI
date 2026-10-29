
using GestionDeProductosAPI.DTOs;
using GestionDeProductosAPI.Models;
using GestionDeProductosAPI.Repositories;

namespace GestionDeProductosAPI.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public List<ProductoDto> ObtenerTodos()
        {
            List<Producto> productos = _productoRepository.ObtenerTodos();

            return productos.Select(ConvertirADto).ToList();
        }

        public ProductoDto? ObtenerPorId(int id)
        {
            Producto? producto = _productoRepository.ObtenerPorId(id);

            if (producto == null)
            {
                return null;
            }

            return ConvertirADto(producto);
        }

        public ProductoDto Crear(CreateProductoDto productoDto)
        {
            Producto producto = new Producto
            {
                Nombre = productoDto.Nombre,
                Precio = productoDto.Precio,
                Categoria = productoDto.Categoria,
                Activo = true
            };

            Producto productoCreado = _productoRepository.Agregar(producto);

            return ConvertirADto(productoCreado);
        }

        public bool Actualizar(int id, CreateProductoDto productoDto)
        {
            Producto? productoExistente = _productoRepository.ObtenerPorId(id);

            if (productoExistente == null)
            {
                return false;
            }

            productoExistente.Nombre = productoDto.Nombre;
            productoExistente.Precio = productoDto.Precio;
            productoExistente.Categoria = productoDto.Categoria;

            return _productoRepository.Actualizar(productoExistente);
        }

        public bool Eliminar(int id)
        {
            return _productoRepository.Eliminar(id);
        }

        private static ProductoDto ConvertirADto(Producto producto)
        {
            return new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Categoria = producto.Categoria,
                Activo = producto.Activo
            };
        }
    }
}

//Inyección de dependencias: recibe IProductoRepository mediante el constructor, sin tener que crear el repositorio manualmente.

//Conversión a DTO: ConvertirADto() transforma una entidad Producto en un ProductoDto, para que la API no devuelva directamente la entidad.

//Creación: convierte los datos recibidos en un producto nuevo y lo guarda mediante el repositorio. El producto comienza con Activo = true.

//Actualización: comprueba que el producto exista antes de modificar sus datos.

//Eliminación: delega la operación al repositorio y devuelve si se pudo realizar.

//Select(ConvertirADto).ToList() permite transformar cada producto de una lista en su DTO correspondiente.