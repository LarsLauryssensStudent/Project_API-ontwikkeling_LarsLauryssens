using Project_API_ontwikkeling_LarsLauryssens.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Company : ICompany
{
    [Key]
    
    public int Id { get; set; }

    [Required(ErrorMessage = "Company name is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Company name must be between 1 and 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "City is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "City must be between 2 and 50 characters.")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Country is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Country must be between 2 and 50 characters.")]
    public string Country { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "MarketCap must be a non-negative value.")]
    public int MarketCap { get; set; }

    // Foreign key and navigation property for Industry
    [ForeignKey(nameof(Industry))]
    [Required(ErrorMessage = "Industry ID is required.")]
    public int IndustryId { get; set; }

    [JsonIgnore]
    public Industry? Industry { get; set; }

    // Navigation property for one-to-one relationship with Stock
    [JsonIgnore]
    public Stock? Stock { get; set; }
}
