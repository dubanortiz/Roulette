using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette
{
    public class Response
    {
        public object Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public Response()
        {
            this.Status = "OK";
            this.Message = "OK";
        }
    }
}
