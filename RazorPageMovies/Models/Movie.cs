using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageMovies.Models
{
    public class Movie
    {
        // DEFINIR VARIABLES
        public int Id { get; set; }

        // SIMBOLO '?' -> PUEDE O NO GUARDARSE EN LA ESTRUCURA DE DATOS (NULL)
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string? Title { get; set; }

        //SE UTILIZA PARA DAR UN FORMATO ESPECÍFICO AL TIPO DE DATO QUE SE SOLICITA
        [Display(Name = "Realese Date")]
        [DataType(DataType.Date)]
        public DateTime RealeseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public String? Genre { get; set; }

        [Display(Name = "Budget (M)")]
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string? Rated { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        public string? Director { get; set; }

        /*
            1.- Creamos una carpeta dentro de Pages con un nombre similar al Modelo.
            2.- Le damos clic derecho / agregar / Nuevo elemento con scaffold (Elegimos el modelo y creamos la parte de BD)
            3.- Herramientas / Administrador de paquetes Nuget / Consola [...]
                -- Add-Migration InitialCreate
                -- Update-Database
         */
    }
}
