using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TSCS2.Controllers
{
    public class MyCourseController : Controller
    {
        String connectionString = @"Data Source=DESKTOP-VJNJ93K\SQLEXPRESS;Initial Catalog=TSCS;Integrated Security=True";
        [HttpGet]
        // GET: Course
        public ActionResult Index()
        {
            DataTable dtblCourse = new DataTable();
            int id = Convert.ToInt32(Session["id"]);
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Course where id=@id", sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@id", id);
                sqlDa.Fill(dtblCourse);
            }
            return View(dtblCourse);
        }

        // GET: MyCourse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyCourse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyCourse/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyCourse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyCourse/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyCourse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyCourse/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
