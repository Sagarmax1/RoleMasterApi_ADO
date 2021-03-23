using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMasterApi_ADO.Models
{
    public class UpdateRoleModel
    {
        public int id { get; set; }
        //  public int ParentRoleId { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string status { get; set; }
        public string user { get; set; }
    }
}
