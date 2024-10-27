
namespace Project_API_ontwikkeling_LarsLauryssens.Models
{
    public class Stock : IStock
    {
        public int Id { get; set; }
        public string Name {  get; set; } = string.Empty;
        public int CompanyId { get; set; }
    }
}
