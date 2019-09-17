using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSCS2.Models;

namespace TSCS2.Controllers
{
    public class RegistrationTController : Controller
    {
        string cs = @"Data Source=DESKTOP-VJNJ93K\SQLEXPRESS;Initial Catalog=TSCS;Integrated Security=True";
        public ActionResult Index()
        {
            return View();
        }


        // POST: Registration/Insert
        [HttpPost]
        public ActionResult Insert(FormCollection collection)
        {
            RegistrationModelT registrationModelT = new RegistrationModelT
            {
                firstname = collection["firstname"],
                lastname = collection["lastname"],
                username = collection["username"],
                password = collection["password"],
                mobile_no = collection["mobile_no"]
            };


            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "insert into loginT values(@firstname,@lastname,@username,@password,@mobile_no)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@firstname", registrationModelT.firstname);
                sqlCommand.Parameters.AddWithValue("@lastname", registrationModelT.lastname);
                sqlCommand.Parameters.AddWithValue("@username", registrationModelT.username);
                sqlCommand.Parameters.AddWithValue("@password", registrationModelT.password);
                sqlCommand.Parameters.AddWithValue("@mobile_no", registrationModelT.mobile_no);

                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }

            return RedirectToAction("Index");

        }


    }
}
