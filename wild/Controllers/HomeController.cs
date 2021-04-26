using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wild.Models;

namespace wild.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            string con = "Data Source=(local);Initial Catalog=pubs;Integrated Security=SSPI;";
            string query = "select * from t_member where siteid = H15";
            DataSet ds = null;
            SqlConnection sql = null;
            try
            {
                sql = new SqlConnection(con);
                sql.Open();
                SqlCommand cmd = new SqlCommand(query,sql);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                if (sql != null)
                {
                    sql.Close();
                }
            }
            

            return View();
        }
    }
}
