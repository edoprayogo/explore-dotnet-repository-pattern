namespace explore_pattern.Domain.Entities
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }

}
