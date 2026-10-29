using System.ComponentModel.DataAnnotations;                                        //Permite utilizar los atributos de validación.

namespace GestionDeProductosAPI.DTOs
{
    public class CreateProductoDto
    {                                                                               //ErrorMessage: Define el mensaje que se mostrará cuando el dato no cumpla la regla.
        [Required(ErrorMessage = "El nombre es obligatorio.")]                      //[Required]: Indica que el campo es obligatorio.
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]       //Limita el nombre a entre 3 y 100 caracteres.
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(typeof(decimal), "0.01", "999999999",                                //[Range()]: establece que el precio debe ser mayor que cero.
            ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public string Categoria { get; set; } = string.Empty;
    }
}