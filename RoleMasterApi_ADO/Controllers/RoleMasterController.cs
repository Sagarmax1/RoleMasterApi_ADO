using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleMasterApi_ADO.Models;
using RoleMasterApi_ADO.Repository.BAL;
using RoleMasterApi_ADO.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMasterApi_ADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleMasterController : ControllerBase
    {

        private readonly RoleMasterRepository _roleMasterRepository;

        ResponseMessage responsemessage;

        ResponseMessage2 responsemessage2;

        public RoleMasterController()
        {
            _roleMasterRepository = new RoleMasterRepository();
        }


        [HttpPost("Insert")]
        public ActionResult Save([FromBody] InsertRoleModel insertRoleModel)
        {
            if (ModelState.IsValid)
            {
                var inserrdata = _roleMasterRepository.InsertRoleMaster(insertRoleModel);
                if (inserrdata != 0)
                {
                    responsemessage2 = new ResponseMessage2("success", "");

                }

                else
                {
                    responsemessage2 = new ResponseMessage2("Failed", "");

                }

            }

            return Ok(responsemessage2);

        }


        [HttpPut("Update")]
        public ActionResult Update(UpdateRoleModel updateRoleModel)      // working Ok
        {
            if (ModelState.IsValid)
            {
                _roleMasterRepository.UpdateRoleMaster(updateRoleModel);

                if (updateRoleModel != null)
                {
                    responsemessage2 = new ResponseMessage2("success", "");
                }
                else
                {
                    responsemessage2 = new ResponseMessage2("Failed", "");
                }

            }

            return Ok(responsemessage2);

        }




        [HttpDelete("BulkDelete")]
        public async Task<ActionResult<RoleModel>> Delete([FromBody]RoleModel roleModel)
        {
            if(roleModel == null)
            {
                return BadRequest("Invalid State");
            }
            int[] rollid = roleModel.id;  // For Multiple RoleId Sepration by ;
            var newrollid = String.Join(";", rollid);

            _roleMasterRepository.BulkDelete(newrollid);
          

            if (newrollid != null)
            {
                responsemessage2 = new ResponseMessage2("success", "");

            }
            else
            {
                responsemessage2 = new ResponseMessage2("failure", "Could not Delete");

            }
            return Ok(responsemessage2);
        }



        [HttpPut("Delete")]
        public async Task<ActionResult<RoleModel>> DeleteSingle([FromQuery] string id)
        {
            if (id == null)
            {
                return BadRequest("Invalid State");
            }

          _roleMasterRepository.BulkDelete(id);


            if (id != null)
            {
                responsemessage2 = new ResponseMessage2("success", "");

            }
            else
            {
                responsemessage2 = new ResponseMessage2("failure", "Could not Delete");

            }
            return Ok(responsemessage2);
        }




        [HttpGet("role")]
        public IActionResult PagingQuery([FromQuery] RoleMasterPaging roleMasterPaging)
        {

            string totalRecords = string.Empty;
            var res = _roleMasterRepository.InsertPagingQuery(roleMasterPaging, ref totalRecords);



            if (res != null)
            {
                responsemessage = new ResponseMessage("success", "", res, totalRecords.ToString());

            }
            else
            {
                responsemessage = new ResponseMessage("failure", "", res, totalRecords.ToString());

            }

            return Ok(responsemessage);
        }




       

    }
}
