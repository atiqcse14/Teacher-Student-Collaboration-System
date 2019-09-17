using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSCS2.Models;

namespace TSCS2.Controllers
{
    public class RegistrationController : Controller
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
            RegistrationModel registrationModel = new RegistrationModel
            {
                firstname = collection["firstname"],
                lastname = collection["lastname"],
                username = collection["username"],
                password = collection["password"],
                mobile_no = collection["mobile_no"]
            };


            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "insert into login values(@firstname,@lastname,@username,@password,@mobile_no)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@firstname", registrationModel.firstname);
                sqlCommand.Parameters.AddWithValue("@lastname", registrationModel.lastname);
                sqlCommand.Parameters.AddWithValue("@username", registrationModel.username);
                sqlCommand.Parameters.AddWithValue("@password", registrationModel.password);
                sqlCommand.Parameters.AddWithValue("@mobile_no", registrationModel.mobile_no);              

                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }

            return RedirectToAction("Index");

        }


    }
}
