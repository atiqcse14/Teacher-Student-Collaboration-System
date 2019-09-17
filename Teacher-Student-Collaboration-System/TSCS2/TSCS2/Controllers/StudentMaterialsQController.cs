using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSCS2.Models;

namespace TSCS2.Controllers
{
    public class StudentMaterialsQController : Controller
    {
        // GET: StudentMaterials
        public ActionResult Index(int id)
        {
            int pp = id;
            return View(GetFiles(pp));

        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile, int id)
        {


            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            string constr = @"Data Source=DESKTOP-VJNJ93K\SQLEXPRESS;Initial Catalog=TSCS;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO tblFilesQ VALUES (@Name, @ContentType, @Data,@cid)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Name", Path.GetFileName(postedFile.FileName));
                    cmd.Parameters.AddWithValue("@ContentType", postedFile.ContentType);
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    cmd.Parameters.AddWithValue("@cid", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            return View(GetFiles(id));
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            byte[] bytes;
            string fileName, contentType;
            string constr = @"Data Source=DESKTOP-VJNJ93K\SQLEXPRESS;Initial Catalog=TSCS;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Name, Data, ContentType FROM tblFilesQ WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", fileId);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }

            return File(bytes, contentType, fileName);
        }

        private static List<FileModel> GetFiles(int id)
        {
            int pp = id;
            List<FileModel> files = new List<FileModel>();
            string constr = @"Data Source=DESKTOP-VJNJ93K\SQLEXPRESS;Initial Catalog=TSCS;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblFilesQ join Course on tblFilesQ.cid = Course.CourseNo Where Course.CourseNo=" + pp))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            files.Add(new FileModel
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Name = sdr["Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return files;
        }
    }
}