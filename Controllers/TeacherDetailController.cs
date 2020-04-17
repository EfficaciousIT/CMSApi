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
    public class TeacherDetailController : ApiController
    {
        Database.DB record = new Database.DB();
        public DataSet Get(string command, string intSchool_id)
        {
            TeacherDetail teacherdetail = new TeacherDetail();
            teacherdetail.intSchool_id = Convert.ToInt32(intSchool_id);
            DataSet ds = record.TeacherDetails(command, teacherdetail);
            return ds;
        }
    }
}
