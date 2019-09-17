using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TSCS2.Controllers
{
    public class ContactController : Controller
    {
        String connectionString = @"Data Source=DESKTOP-VJNJ93K\SQLEXPRESS;Initial Catalog=TSCS;Integrated Security=True";
        [HttpGet]
        // GET: Course
        public ActionResult Index()
        {
            DataTable dtblCourse = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select firstname,lastname,mobile_name,CourseName from loginT inner join Course  on loginT.id=Course.id order by firstname asc", sqlCon);
                sqlDa.Fill(dtblCourse);
            }
            return View(dtblCourse);
        }

    }
}