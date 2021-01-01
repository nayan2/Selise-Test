using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTest.Data.Core.Domain
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Discount { get; set; }
        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
    }
}
