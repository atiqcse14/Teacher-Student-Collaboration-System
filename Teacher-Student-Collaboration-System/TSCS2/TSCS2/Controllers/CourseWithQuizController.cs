using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSCS2.Models;

namespace TSCS2.Controllers
{
    public class CourseWithQuizController : Controller
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Course", sqlCon);
                sqlDa.Fill(dtblCourse);
            }
            return View(dtblCourse);
        }
    }
}