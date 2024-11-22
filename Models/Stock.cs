using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project_API_ontwikkeling_LarsLauryssens.Models
{
    public class Stock : IStock
    {
        [Key]
        public int Id { get; set; }

        // required en maximaal 10 characters, normaal gezien zijn tickers (stocknames) zelfs maar maximaal 5 characters
        [Required(ErrorMessage = "Stock name is required.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Stock name must be between 1 and 10 characters.")]
        public string Name { get; set; } = string.Empty;

        // required, de foreign key, deze mag nooit negatief zijn en aanwezig zijn in de companies, maar dat kijken we zo na in de service
        [Required]
        [ForeignKey(nameof(Company))]
        [Range(1, int.MaxValue, ErrorMessage = "Company ID must be a positive number.")]
        public int? CompanyId { get; set; }

        // Navigation property
        [JsonIgnore]
        public Company? Company { get; set; }
    }
}
