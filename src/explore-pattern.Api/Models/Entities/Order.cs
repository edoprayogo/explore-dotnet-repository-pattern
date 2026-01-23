using System;
using System.Collections.Generic;
using System.Text;

namespace explore_pattern.Api.Models.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public Product Product { get; set; } = default!;
    }
}
