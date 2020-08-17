using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_WebApi.Models
{
  
    public partial class StudentStandardWise
    {
        public int intschool_id { get; set; }
        public int Academic_id { get; set; }
        public int Division_id { get; set; }
        public int Standard_id { get; set; }
    }
}