using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMasterApi_ADO.Models
{
    public class InsertRoleModel
    {
        public string name { get; set; }
        public string shortName { get; set; }

        public string status { get; set; }
       // public string LogedInUser { get; set; }
    }
}
