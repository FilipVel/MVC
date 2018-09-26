using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class AddToRoleModel
    {

        public string Email { get; set; }
        public List<String> Roles { get; set; }

        public string SelectedRole { get; set; }
        public AddToRoleModel()
        {
            Roles = new List<String>();

        }
    }
}