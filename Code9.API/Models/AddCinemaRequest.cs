using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Code9.API.Models
{
    public class AddCinemaRequest
    {
        [Required]
        [MinLength(3)]
        [StringLength(15, ErrorMessage = "The cinema name cannot exceed 15 characters")]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "The cinema street name cannot be below 5 characters")]
        public string Street { get; set; }
        [Required]
        [NotNull]
        public int NumberofAuditoriums { get; set; }
    }
}
