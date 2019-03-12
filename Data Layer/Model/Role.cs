using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Layer.Model
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string Rolename { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
