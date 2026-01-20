using System;
using System.Collections.Generic;
using System.Text;

namespace explore_pattern.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }

        public Category Category { get; set; } = default!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
