namespace Project_API_ontwikkeling_LarsLauryssens.Models
{
    public interface ICompany
    {
        public int Id { get; set;}
        public string Name { get; set; } 
        public string City {  get; set; } 
        public string Country {  get; set; }
        public int MarketCap {  get; set; }
        public int IndustryId { get; set; }

    }
}
