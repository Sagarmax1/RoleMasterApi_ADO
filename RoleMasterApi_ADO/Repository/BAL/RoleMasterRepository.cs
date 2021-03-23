using Microsoft.Extensions.Configuration;
using RoleMasterApi_ADO.Models;
using RoleMasterApi_ADO.Repository.DataAccesslayer;
using RoleMasterApi_ADO.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMasterApi_ADO.Repository.BAL
{
    public class RoleMasterRepository : IRoleMasterRepository
    {

        RoleMasterDAL roleMasterDAL = new RoleMasterDAL();


        public void BulkDelete(string ids)
        {
            roleMasterDAL.BulkDelete(ids);
        }



        public List<RoleMasterPagingOutPut> InsertPagingQuery(RoleMasterPaging roleMasterPaging, ref string totalcount)
        {
            return roleMasterDAL.InsertPagingQuery(roleMasterPaging, ref totalcount);

        }


       


        public int InsertRoleMaster(InsertRoleModel insertRoleModel)
        {
            return roleMasterDAL.InsertRoleMaster(insertRoleModel);
        }

        public void UpdateRoleMaster(UpdateRoleModel updateRoleModel)   // Working Ok
        {
            roleMasterDAL.UpdateRoleMaster(updateRoleModel);

        }


    }
}
