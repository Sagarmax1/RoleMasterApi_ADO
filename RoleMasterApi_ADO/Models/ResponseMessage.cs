using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMasterApi_ADO.Models
{
    public class ResponseMessage 
    {
        public string status { get; set; }
        public string message { get; set; }

        public dynamic data { get; set; }
        public string totalRecords { get; set; }
        public ResponseMessage(string Status, string Message, dynamic Data, string TotalCount)
        {

            this.status = Status;
            this.message = Message;
            this.data = Data;
            this.totalRecords = TotalCount;
        }
    }



    public class ResponseMessage2
    {
        public string status { get; set; }
        public string  message { get; set; }

        
        public ResponseMessage2( string Status , string Message)
        {

            this.status = Status;
            this.message = Message;
           
            
        }
    }
}
