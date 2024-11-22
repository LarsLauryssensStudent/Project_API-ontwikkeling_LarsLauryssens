using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project_API_ontwikkeling_LarsLauryssens.Models
{
    public class Industry : IIndustry
    {
        [Key]
        public int Id { get; set; }

        // required en maximaal 50 characters, minimaal 3
        [Required(ErrorMessage = "Industry name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Industry name must be between 3 and 50 characters.")]
        public string Name { get; set; } = string.Empty;

        // Navigation property voor de een op veel relatie met companies
        [JsonIgnore]
        public ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}
