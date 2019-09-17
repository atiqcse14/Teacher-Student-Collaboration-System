using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using TSCS2.Models;
namespace TSCS2.Controllers
{
    public class HomeSController : Controller
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


        public ActionResult startS() {

            return View();
        }

    }
}