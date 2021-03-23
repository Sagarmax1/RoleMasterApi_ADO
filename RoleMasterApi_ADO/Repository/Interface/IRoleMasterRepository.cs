using RoleMasterApi_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMasterApi_ADO.Repository.Interface
{
      public interface IRoleMasterRepository
    {

        

        void BulkDelete(string ids); // New Method

         List<RoleMasterPagingOutPut> InsertPagingQuery(RoleMasterPaging roleMasterPaging , ref string totalcount); // Working Ok

     

        int InsertRoleMaster(InsertRoleModel insertRoleModel);  // Working Ok

        void UpdateRoleMaster(UpdateRoleModel updateRoleModel); //Working Ok

        


        

    }
}
