using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace simple_crud.Models
{
    [Table("colegio")]
    public class Colegio
    {
        [Column("id")]
        [Key]
        [Required]
        [ForeignKey("Estudiante")]
        public int id { get; set; }

        [Column("nombreColegio")]
        [StringLength(255)]
        [Required]
        public string nombreColegio { get; set; }

        [Column("codUbigeo")]
        [StringLength(50)]
        public string codUbigeo { get; set; }

        [Column("estado")]
        public bool estado { get; set; }

        public List<Estudiante> estudiantes { get; set; }
    }
}
