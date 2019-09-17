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
    public class CourseController : Controller
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

        

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CourseModel());
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(CourseModel courseModel)
        {
            int uid = Convert.ToInt32(Session["id"]);
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Course VALUES(@CourseName,@CourseTitle,@id)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@CourseName", courseModel.CourseName);
                sqlCmd.Parameters.AddWithValue("@CourseTitle", courseModel.CourseTitle);
                sqlCmd.Parameters.AddWithValue("@id", uid);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            CourseModel courseModel = new CourseModel();
            DataTable dtblCourse = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Course Where CourseNo = @CourseNo";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@CourseNo", id);
                sqlDa.Fill(dtblCourse);
            }
            if (dtblCourse.Rows.Count == 1)
            {
                courseModel.CourseNo = Convert.ToInt32(dtblCourse.Rows[0][0].ToString());
                courseModel.CourseName = dtblCourse.Rows[0][1].ToString();
                courseModel.CourseTitle = dtblCourse.Rows[0][2].ToString();
                
                return View(courseModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(CourseModel courseModel)
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Course SET CourseName = @CourseName , CourseTitle= @CourseTitle WHere CourseNo = @CourseNo";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@CourseNo", courseModel.CourseNo);
                sqlCmd.Parameters.AddWithValue("@CourseName", courseModel.CourseName);
                sqlCmd.Parameters.AddWithValue("@CourseTitle", courseModel.CourseTitle);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Course WHere CourseNo = @CourseNo";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@CourseNo", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index","MyCourse");
        }

      
    }
}
