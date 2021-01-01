using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeliseTest.Data.Core.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
