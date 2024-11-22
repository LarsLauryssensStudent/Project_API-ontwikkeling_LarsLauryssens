namespace Project_API_ontwikkeling_LarsLauryssens.Models
{
    public interface IStock
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int? CompanyId { get; set; }
}
}
