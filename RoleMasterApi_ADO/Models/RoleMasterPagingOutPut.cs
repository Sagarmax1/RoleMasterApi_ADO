using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMasterApi_ADO.Models
{
    public class RoleMasterOut
    {
        //  public int TotalCount { get; set; }

        public string TotalCount { get; set; }

        public List<RoleMasterPagingOutPut> data { get; set; }
    }
    public class RoleMasterPagingOutPut
    {
        //public string? ROLEID { get; set; }
        //public string? PARENTROLEID { get; set; }
        //public string? ROLESNAME { get; set; }

        //public string? DISPLAYNAME { get; set; }
        //public string? ACTIVEFLAG { get; set; }

        public int id { get; set; }
        public string displayname { get; set; }

        public string rolesname { get; set; }
        public string activeflag { get; set; }

    }
}
