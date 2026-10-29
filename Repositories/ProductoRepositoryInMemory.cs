
using GestionDeProductosAPI.Models;

namespace GestionDeProductosAPI.Repositories
{
    public class ProductoRepositoryInMemory : IProductoRepository
    {
        private static readonly List<Producto> _productos = new();

        private static int _siguienteId = 1;

        public List<Producto> ObtenerTodos()
        {
            return _productos.ToList();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public Producto Agregar(Producto producto)
        {
            producto.Id = _siguienteId++;

            _productos.Add(producto);

            return producto;
        }

        public bool Actualizar(Producto producto)
        {
            Producto? productoExistente = ObtenerPorId(producto.Id);

            if (productoExistente == null)
            {
                return false;
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Precio = producto.Precio;
            productoExistente.Categoria = producto.Categoria;
            productoExistente.Activo = producto.Activo;

            return true;
        }

        public bool Eliminar(int id)
        {
            Producto? producto = ObtenerPorId(id);

            if (producto == null)
            {
                return false;
            }

            _productos.Remove(producto);

            return true;
        }
    }
}
