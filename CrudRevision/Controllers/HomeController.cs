using CrudRevision.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudRevision.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con=new SqlConnection("Data Source=NITESH\\SQLEXPRESS;Initial Catalog=crudrevision;Integrated Security=True");
        public ActionResult Index()
        {
            SqlCommand cmd = new SqlCommand("sp_register", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action",2);
            DataTable dt=new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            return View(dt);
        }
        [HttpPost]
        public ActionResult Index(Register r)
        {
           
            SqlCommand cmd = new SqlCommand("sp_register",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name",r.name);
            cmd.Parameters.AddWithValue("@email",r.email);
            cmd.Parameters.AddWithValue("@gender",r.gender);
            cmd.Parameters.AddWithValue("@popic",r.ppic.FileName);
            cmd.Parameters.AddWithValue("@pass",r.pass);
            cmd.Parameters.AddWithValue("@action",1);
            con.Open();
            int res=cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                return Content("<script>alert('Data Inserted Successfully');location.href='/home/index'</script>");
            }
            else
            {
                return Content("<script>alert('Data Insertion Failed');location.href='/home/index'</script>");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}