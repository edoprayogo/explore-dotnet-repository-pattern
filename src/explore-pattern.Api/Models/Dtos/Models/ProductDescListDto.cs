namespace explore_pattern.Api.Models.Dtos.Models
{
    public class ProductDescListDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string StoreName { get; set; } = null!;
        public decimal Price { get; set; }
    }

}
