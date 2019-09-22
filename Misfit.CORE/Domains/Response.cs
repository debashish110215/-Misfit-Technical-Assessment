using System;
using System.Collections.Generic;
using System.Text;

namespace Misfit.CORE.Domains
{
    public class Response<T>
    {
        public Response()
        {
            Success = true;
            ResponseOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        }
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public string ResponseOn { get; set; }
    }
}
