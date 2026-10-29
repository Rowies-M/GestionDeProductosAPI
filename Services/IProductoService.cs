
using GestionDeProductosAPI.DTOs;

namespace GestionDeProductosAPI.Services
{
    public interface IProductoService
    {
        List<ProductoDto> ObtenerTodos();

        ProductoDto? ObtenerPorId(int id);

        ProductoDto Crear(CreateProductoDto productoDto);               //Recibe los datos necesarios para crear un producto.

        bool Actualizar(int id, CreateProductoDto productoDto);

        bool Eliminar(int id);
    }
}

//Este archivo define las operaciones que deberá ofrecer nuestro servicio, pero no contiene su implementación. Esa tarea corresponderá a ProductoService.cs.