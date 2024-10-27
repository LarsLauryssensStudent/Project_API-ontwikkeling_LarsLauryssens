
namespace Project_API_ontwikkeling_LarsLauryssens.Models
{
    public class Company : ICompany
    {
        public int Id {  get; set; }
        public string Name {  get; set; } = string.Empty;
        public int IndustryId {  get; set; }
        public string City { get; set; } = string.Empty;
        public string Country {get; set; } = string.Empty;
        public int MarketCap {get; set; }
    }
}
