using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SeliseTest.Data.Core.Domain.DTO
{
    public class CustomerDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string UserGroup { get; set; }
        public int UserGroupId => (int)(UserGroup)Enum.Parse(typeof(UserGroup), this.UserGroup, true);
    }

    public enum UserGroup: int
    {
        Silver = 1,
        Platinum = 2,
        Gold = 3
    } 
}
