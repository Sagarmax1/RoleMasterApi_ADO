using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMasterApi_ADO.Models
{
    public class RoleMasterPaging
    {
        //public int? id { get; set; }

        //public string? sortName { get; set; }
        //public string? name { get; set; }
        //public string? status { get; set; }
        //public string? LogedInUser { get; set; }

        //public int Page { get; set; }

        //public int limit { get; set; }

        //public string? sortCol { get; set; }
        //public string? sortOrder { get; set; }

        //public int totalcount { get; set; }

        public int? id { get; set; }

        public string? rolesname { get; set; }
        public string? displayname { get; set; }
        public char? activeflag { get; set; }
     
        public string page { get; set; }

        public string limit { get; set; }

        public string? sortCol { get; set; }
        public string? sortOrder { get; set; }


    }
}
