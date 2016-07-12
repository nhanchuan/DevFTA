using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UserAdminBLL
    {
        DataServices dt = new DataServices();

        /// <summary>
        /// Create New User Admin
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Email"></param>
        /// <param name="Passwords"></param>
        /// <returns></returns>
        public Boolean NewUserAdmin(string UserName, string Email, string Passwords)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "Exec NewUserAdmin @UserName,@Email,@Passwords";
            SqlParameter pUserName = new SqlParameter("@UserName", UserName);
            SqlParameter pEmail = (Email == "") ? new SqlParameter("@Email", DBNull.Value) : new SqlParameter("@Email", Email);
            SqlParameter pPasswords = (Passwords == "") ? new SqlParameter("@Passwords", DBNull.Value) : new SqlParameter("@Passwords", Passwords);
            this.dt.Updatedata(sql, pUserName, pEmail, pPasswords);
            this.dt.CloseConnection();
            return true;
        }
        public List<UserAdmin> ListUserWithName(string UserName)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from UserAdmin where UserName=@UserName";
            SqlParameter pUserName = new SqlParameter("@UserName", UserName);
            DataTable tb = dt.DATable(sql, pUserName);
            List<UserAdmin> lst = new List<UserAdmin>();
            foreach(DataRow r in tb.Rows)
            {
                UserAdmin ad = new UserAdmin();
                ad.ID = (int)r["ID"];
                ad.UserName = (string)r["UserName"];
                ad.Email = (string.IsNullOrEmpty(r["Email"].ToString())) ? "" : (string)r["Email"];
                ad.Passwords = (string.IsNullOrEmpty(r["Passwords"].ToString())) ? "" : (string)r["Passwords"];
                lst.Add(ad);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<UserAdmin> login_Adminform(string key, string passwords)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "Exec login_Adminform @key,@passwords";
            SqlParameter pkey = new SqlParameter("@key", key);
            SqlParameter ppasswords = new SqlParameter("@passwords", passwords);
            DataTable tb = dt.DATable(sql, pkey, ppasswords);
            List<UserAdmin> lst = new List<UserAdmin>();
            foreach (DataRow r in tb.Rows)
            {
                UserAdmin ad = new UserAdmin();
                ad.ID = (int)r["ID"];
                ad.UserName = (string)r["UserName"];
                ad.Email = (string.IsNullOrEmpty(r["Email"].ToString())) ? "" : (string)r["Email"];
                ad.Passwords = (string.IsNullOrEmpty(r["Passwords"].ToString())) ? "" : (string)r["Passwords"];
                lst.Add(ad);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<UserAdmin> ListUserWithEmail(string Email)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from UserAdmin where Email=@Email";
            SqlParameter pEmail = new SqlParameter("@Email", Email);
            DataTable tb = dt.DATable(sql, pEmail);
            List<UserAdmin> lst = new List<UserAdmin>();
            foreach (DataRow r in tb.Rows)
            {
                UserAdmin ad = new UserAdmin();
                ad.ID = (int)r["ID"];
                ad.UserName = (string)r["UserName"];
                ad.Email = (string.IsNullOrEmpty(r["Email"].ToString())) ? "" : (string)r["Email"];
                ad.Passwords = (string.IsNullOrEmpty(r["Passwords"].ToString())) ? "" : (string)r["Passwords"];
                lst.Add(ad);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public int GetUserIDWithName(string UserName)
        {
            int uid = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select * from UserAdmin where UserName=@UserName";
            SqlParameter pUserName = new SqlParameter("@UserName", UserName);
            DataTable tb = dt.DATable(sql, pUserName);
            foreach (DataRow r in tb.Rows)
            {
                uid = (int)r["ID"];
            }
            this.dt.CloseConnection();
            return uid;
        }

    }
}
