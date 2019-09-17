using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSCS2.Models;

namespace TSCS2.Controllers
{
    public class LoginController : Controller
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
            LoginModel loginModel = new LoginModel
            {
                username = collection["username"],
                password = collection["password"]
            };

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "(select count(*) from login where username=@username AND password=@password)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@username", loginModel.username);
                sqlCommand.Parameters.AddWithValue("@password", loginModel.password);

                conn.Open();
                matching_result = (int)sqlCommand.ExecuteScalar();
                //Exexute scalar returns a single value,return type is object,
                //we can convert it at any type.
            }
            if (matching_result > 0)
            {
                Session["id"] = loginModel.id;
                Session["username"] = loginModel.username;
                return RedirectToAction("startS", "HomeS");
            }
            else
            {
                return View("WrongLogin");
            }

        }
    }
}
