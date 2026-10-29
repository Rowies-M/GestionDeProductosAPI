namespace GestionDeProductosAPI.Models
{
    public class Producto                                       //Esta clase es nuestra entidad de dominio.
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;      //string.Empty: Inicializa las propiedades de texto con una cadena vacía, evitando advertencias por valores nulos.

        public decimal Precio { get; set; }

        public string Categoria { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }
}