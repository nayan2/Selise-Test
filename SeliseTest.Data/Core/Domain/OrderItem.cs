using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeliseTest.Data.Core.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int? OrderId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Completed { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}
