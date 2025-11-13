using System.ComponentModel.DataAnnotations;

namespace T3_Aguilar_Chufandama.Models
{
    public class Libro
    {
        public int Id { get; set; }

    [Display(Name = "Título")]
    [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "El autor es obligatorio")]
        public string Autor { get; set; } = string.Empty;

        [Display(Name = "Tema")]
        [Required(ErrorMessage = "El tema es obligatorio")]
        public string Tema { get; set; } = string.Empty;

        [Display(Name = "Editorial")]
        [Required(ErrorMessage = "La editorial es obligatoria")]
        public string Editorial { get; set; } = string.Empty;

    [Display(Name = "Año de publicación")]
    [Required(ErrorMessage = "El año de publicación es obligatorio")]
    [Range(1900, 3000, ErrorMessage = "El año de publicación debe estar entre 1900 y 3000")]
        public int AnioPublicacion { get; set; }

    [Display(Name = "Páginas")]
    [Required(ErrorMessage = "Las páginas son obligatorias")]
    [Range(10, 1000, ErrorMessage = "Las páginas deben estar entre 10 y 1000")]
        public int Paginas { get; set; }

    [Display(Name = "Categoría")]
    [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Categoria { get; set; } = string.Empty;

    [Display(Name = "Material")]
    [Required(ErrorMessage = "El material es obligatorio")]
        public string Material { get; set; } = string.Empty;

        [Display(Name = "Copias")]
        [Required(ErrorMessage = "Las copias son obligatorias")]
        [Range(1, 20, ErrorMessage = "Las copias deben estar entre 1 y 20")]
        public int Copias { get; set; }
    }
}