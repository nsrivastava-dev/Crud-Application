using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudRevision.Models
{
    public class Register
    {
        public string name { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string gender { get; set; }
        public HttpPostedFileBase ppic { get; set; }
    }
}