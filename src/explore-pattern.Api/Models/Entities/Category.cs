using System;
using System.Collections.Generic;
using System.Text;

namespace explore_pattern.Api.Models.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public string Name { get; set; } = default!;

        public Store Store { get; set; } = default!;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
