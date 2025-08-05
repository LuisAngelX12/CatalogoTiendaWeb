using System.ComponentModel.DataAnnotations;

namespace CatalogoWeb.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(100)]
        public string Contrasena { get; set; }

        [Required]
        [StringLength(20)]
        public string Rol { get; set; } = "CLIENTE"; // o "ADMIN"
    }
}