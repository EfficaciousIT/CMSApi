using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMS_WebApi.Models;
using System.Data;
namespace CMS_WebApi.Controllers
{
    public class LibraryController : ApiController
    {
        Database.DB record = new Database.DB();
        public DataSet Get(string command, string intSchool_id, string intStandard_id,string intStudent_id)
        {
            Library library = new Library();
            library.intschool_id = Convert.ToInt32(intSchool_id);
            library.intStandard_id = Convert.ToInt32(intStandard_id);
            library.intStudent_id = Convert.ToInt32(intStudent_id);
            DataSet ds = record.LibraryDetail(command, library);
            return ds;
        }
    }
}
