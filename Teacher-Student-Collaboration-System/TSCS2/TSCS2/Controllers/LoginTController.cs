using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSCS2.Models;

namespace TSCS2.Controllers
{
    public class LoginTController : Controller
    {
        string cs = @"Data Source=DESKTOP-VJNJ93K\SQLEXPRESS;Initial Catalog=TSCS;Integrated Security=True";
        public ActionResult Index()
        {
            return View();
        }


        // POST: Login/LoginCheck
        [HttpPost]
        public ActionResult LoginCheck(FormCollection collection)
        {
            int matching_result;
            LoginModelT loginModelT = new LoginModelT
            {
                username = collection["username"],
               
                password = collection["password"]
            };
          
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "(select count(*) from loginT where username=@username AND password=@password)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@username", loginModelT.username);
                sqlCommand.Parameters.AddWithValue("@password", loginModelT.password);

                conn.Open();
                matching_result = (int)sqlCommand.ExecuteScalar();
                //Exexute scalar returns a single value,return type is object,
                //we can convert it at any type.
            }
            if (matching_result > 0)
            {
                int id;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    DataTable dtblCourse = new DataTable();
                   
                    string query = "select id from loginT where username=@username AND password=@password";
           
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query, conn);
                    sqlDa.SelectCommand.Parameters.AddWithValue("@username", loginModelT.username);
                    sqlDa.SelectCommand.Parameters.AddWithValue("@password", loginModelT.password);
                    sqlDa.Fill(dtblCourse);
                    DataRow row = dtblCourse.Rows[0];
                    id = Convert.ToInt32(row[0].ToString());
                    
                   
                    
                }

                
                Session["id"] = id;
                int ppp = id;
                Session["username"] = loginModelT.username;
                return RedirectToAction("Index", "HomeT");
            }
            else
            {
                return View("WrongLogin");
            }

        }
    }
}
