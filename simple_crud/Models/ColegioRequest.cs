using System.ComponentModel.DataAnnotations;

namespace simple_crud.Models
{
    public class ColegioRequest
    {
        [Required]
        public string nombre { get; set; }

        [Required]
        public string codUbigeo { get; set; }

        [Required]
        public bool estado { get; set; }
    }
}
