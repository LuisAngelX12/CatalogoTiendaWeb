using System.ComponentModel.DataAnnotations;

namespace CatalogoWeb.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public string ImagenUrl { get; set; } // Ruta en wwwroot/imagenes

        public string Categoria { get; set; }
    }
}