namespace GestionDeProductosAPI.DTOs
{
    public class ProductoDto 
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public string Categoria { get; set; } = string.Empty;

        public bool Activo { get; set; }
    }
}

//Este objeto representa los datos que queremos mostrar al cliente cuando consulta un producto. Nuestro servicio se encargará de convertir una entidad Producto en un ProductoDto.