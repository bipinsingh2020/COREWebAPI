using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace COREWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="Name Filed Length should be between 3 and 20")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01,100000,ErrorMessage ="Amount must be greater than 0")]
        public required decimal Price { get; set; }
    }
}
