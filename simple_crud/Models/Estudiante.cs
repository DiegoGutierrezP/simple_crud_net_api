using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace simple_crud.Models
{
    [Table("estudiante")]
    public class Estudiante
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public int numDoc { get; set; }

        [StringLength(200)]
        [Required]
        public string nombre { get; set; }

        [StringLength(200)]
        [Required]
        public string apellidos { get; set; }
        
        public bool estado { get; set; }

        public int colegioId { get; set; }
        public Colegio colegio { get; set; }
    }
}
