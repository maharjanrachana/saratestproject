using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaraPabson.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SaraOnlineResultConnectionString"].ConnectionString);
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        
        public ActionResult CheckUserValidation(string username, string password, int school_code)
        {
            
            int school_code2 = 3030;
            int userSchoolCode = 0;
            con.Open();

            //insert the login record
            InsertLoginRecord(username, password, school_code, school_code2);

            SqlCommand cmd = new SqlCommand("loginSaloko", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", username));
            cmd.Parameters.Add(new SqlParameter("@Jhal", password));
            cmd.Parameters.Add(new SqlParameter("@Sc_1", school_code));
            cmd.Parameters.Add(new SqlParameter("@Sc_2", school_code2));
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    userSchoolCode = Convert.ToInt32(reader["Sc_1"]);
                }
                else {
                    TempData["MSG"] = "User not found. Please register!";
                    return View("~/Views/Account/Login.cshtml");
                }
            }
            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }

            string schoolName = getSchoolNameByCode(userSchoolCode);
            if (String.IsNullOrEmpty(schoolName)) {
                return View("~/Views/Account/Login.cshtml");
            }

            return View("~/Views/Account/Admin.cshtml");
        }

        public string getSchoolNameByCode(int userSchoolCode)
        {
            string schoolName="";
            SqlCommand cmd = new SqlCommand("sp_getSchoolCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Code", userSchoolCode));
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    schoolName = reader["SchoolName"].ToString();
                }
                else
                {
                    TempData["MSG"] = "School not found";
                }
            }
            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
            return schoolName;
        }

        public void InsertLoginRecord(string username, string password, int sc_code1, int sc_code2) {
            SqlCommand cmd = new SqlCommand("sp_InsertLoginName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Potha", username));
            cmd.Parameters.Add(new SqlParameter("@Jhal", password));
            cmd.Parameters.Add(new SqlParameter("@Sc_1", sc_code1));
            cmd.Parameters.Add(new SqlParameter("@Sc_2", sc_code2));
            // cmd.Parameters.Add(new SqlParameter("@whattime", DateTime.Now.ToString("HH:mm:ss tt")));
            cmd.Parameters.Add(new SqlParameter("@whattime", DateTime.Now));
            cmd.Parameters.Add(new SqlParameter("@whatdate", DateTime.Today));
            var pOut = cmd.Parameters.Add("@TransNo", SqlDbType.Int);
            pOut.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
        }
    }
}