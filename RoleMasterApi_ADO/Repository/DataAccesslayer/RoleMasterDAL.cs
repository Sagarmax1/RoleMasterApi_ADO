using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using RoleMasterApi_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMasterApi_ADO.Repository.DataAccesslayer
{
    public class RoleMasterDAL
    {
       

        string MyConnectionString = "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.15.220)(PORT = 1522)))(CONNECT_DATA =(SERVICE_NAME = dev)));User ID=hruser;Password=hruser";
        OracleConnection con;
        int res = 0;
        public int InsertRoleMaster(InsertRoleModel insertRoleModel) // Working Ok
        {
            try
            {
            //  using (OracleConnection con = connection )
            using (con = new OracleConnection(MyConnectionString))
            {

                OracleCommand cmd = new OracleCommand("pkg_api_integration.PROC_VSEC_ROLEMASTER_INS", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_ROLEID", OracleDbType.Int32, DBNull.Value, ParameterDirection.Input);
                cmd.Parameters.Add("P_PARENTROLEID", OracleDbType.Int32, DBNull.Value, ParameterDirection.Input);
                cmd.Parameters.Add("P_ROLESNAME", OracleDbType.Varchar2, insertRoleModel.shortName, ParameterDirection.Input);
                cmd.Parameters.Add("P_DISPLAYNAME", OracleDbType.Varchar2, insertRoleModel.name, ParameterDirection.Input);
                cmd.Parameters.Add("P_ACTIVEFLAG", OracleDbType.Char, insertRoleModel.status.ToLower() == "enabled" ? "Y" : "N", ParameterDirection.Input);
                cmd.Parameters.Add("P_ACTION", OracleDbType.Varchar2, "I", ParameterDirection.Input);
                cmd.Parameters.Add("P_USER", OracleDbType.Varchar2, "Admin", ParameterDirection.Input);
                cmd.Parameters.Add("P_STATUSFLAG", OracleDbType.Varchar2, 200, "", ParameterDirection.Output);//.Value = 200;
                cmd.Parameters.Add("P_ERROR", OracleDbType.Varchar2, 2000, "", ParameterDirection.Output);//.Value = 2000;

                con.Open();
                res = cmd.ExecuteNonQuery();
                if(res >= -1)
                {   
                    return res;
                }

                else
                {  
                    return res;  
                }
               
            }

            }
            catch (Exception ex)
            {

                return res;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateRoleMaster(UpdateRoleModel updateRoleModel) // Working Ok
        {
            try
            {

                using (OracleConnection con = new OracleConnection(MyConnectionString))
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("pkg_api_integration.PROC_VSEC_ROLEMASTER_INS", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_ROLEID", OracleDbType.Int32, updateRoleModel.id, ParameterDirection.Input);
                    cmd.Parameters.Add("P_PARENTROLEID", OracleDbType.Int32, DBNull.Value, ParameterDirection.Input);
                    cmd.Parameters.Add("P_ROLESNAME", OracleDbType.Varchar2, updateRoleModel.shortName, ParameterDirection.Input);
                    cmd.Parameters.Add("P_DISPLAYNAME", OracleDbType.Varchar2, updateRoleModel.name, ParameterDirection.Input);
                    cmd.Parameters.Add("P_ACTIVEFLAG", OracleDbType.Char, updateRoleModel.status.ToLower() == "enabled" ? "Y" : "N", ParameterDirection.Input);
                    cmd.Parameters.Add("P_ACTION", OracleDbType.Varchar2, "U", ParameterDirection.Input);
                    cmd.Parameters.Add("P_USER", OracleDbType.Varchar2, updateRoleModel.user, ParameterDirection.Input);
                    cmd.Parameters.Add("P_STATUSFLAG", OracleDbType.Varchar2, 200, "", ParameterDirection.Output);//.Value = 200;
                    cmd.Parameters.Add("P_ERROR", OracleDbType.Varchar2, 2000, "", ParameterDirection.Output);//.Value = 2000;

                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void BulkDelete(string ids)  // Working Ok
        {
            try
            {
                
                using (OracleConnection con = new OracleConnection(MyConnectionString))
                {
                    OracleCommand cmd = new OracleCommand("pkg_api_integration.PROC_VSEC_ROLEMASTER_DEL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_ROLEID", OracleDbType.Varchar2, ids, ParameterDirection.Input);
                    cmd.Parameters.Add("P_USERID", OracleDbType.Varchar2, ParameterDirection.Input);
                    cmd.Parameters.Add("P_SMSG", OracleDbType.Varchar2,2000,"Admin", ParameterDirection.Output); 
                    cmd.Parameters.Add("P_STATUS", OracleDbType.Varchar2, 200,"", ParameterDirection.Output);
                    cmd.Parameters.Add("P_SCODE", OracleDbType.Varchar2, 2000, "", ParameterDirection.Output); 
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                }
            }
            catch (Exception ex)
            {

                throw ;
            }
        }



        public List<RoleMasterPagingOutPut> InsertPagingQuery(RoleMasterPaging roleMasterPaging, ref string totalcount)
        {
            try
            {
                List<RoleMasterPagingOutPut> objoutput = new List<RoleMasterPagingOutPut>();



                DataSet ds = new DataSet();
                using (OracleConnection con = new OracleConnection(MyConnectionString))
                {


                    string query = "pkg_api_integration.PROC_VSEC_ROLEMASTER_VW";
                    con.Open();
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_ROLEID", OracleDbType.Int32, roleMasterPaging.id, ParameterDirection.Input);
                    cmd.Parameters.Add("P_ROLESNAME", OracleDbType.Varchar2, roleMasterPaging.rolesname, ParameterDirection.Input);
                    cmd.Parameters.Add("P_DISPLAYNAME", OracleDbType.Varchar2, roleMasterPaging.displayname, ParameterDirection.Input);
                    cmd.Parameters.Add("P_ACTIVEFLAG", OracleDbType.Varchar2, roleMasterPaging.activeflag, ParameterDirection.Input);
                    cmd.Parameters.Add("P_SORTCOL", OracleDbType.Varchar2, roleMasterPaging.sortCol, ParameterDirection.Input);
                    cmd.Parameters.Add("P_SORTORDER", OracleDbType.Varchar2, roleMasterPaging.sortOrder, ParameterDirection.Input);
                    cmd.Parameters.Add("P_PAGENO", OracleDbType.Int32, roleMasterPaging.page, ParameterDirection.Input);
                    cmd.Parameters.Add("P_PAGESIZE", OracleDbType.Int32, roleMasterPaging.limit, ParameterDirection.Input);
                    cmd.Parameters.Add("P_DATA", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("p_TotalCount", OracleDbType.Int32, ParameterDirection.Output);
                    cmd.Parameters.Add("P_ERROR", OracleDbType.Varchar2, 2000, "", ParameterDirection.Output);

                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        RoleMasterPagingOutPut output = new RoleMasterPagingOutPut();
                        output.id = Convert.ToInt32(dr["id"].ToString());
                       // output. = dr["PARENTROLEID"].ToString();
                        output.rolesname = dr["rolesname"].ToString();
                        output.displayname = dr["displayname"].ToString();
                        output.activeflag = dr["activeflag"].ToString();
                        objoutput.Add(output);
                    }

                    totalcount = Convert.ToString(cmd.Parameters["p_TotalCount"].Value);

                }

                return objoutput;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



       

    }
}
