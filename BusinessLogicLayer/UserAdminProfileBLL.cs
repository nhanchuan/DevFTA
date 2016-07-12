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
    public class UserAdminProfileBLL
    {
        DataServices dt = new DataServices();
        public DateTime DefaultDate = Convert.ToDateTime("12/12/1900");
        /// <summary>
        /// Create New User Admin with Admin ID
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="AdminID"></param>
        /// <returns></returns>
        public Boolean CreateUserAdminProfile(string FirstName, string LastName, int AdminID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "insert into UserAdminProfile(AdminID,FirstName,LastName) values(@AdminID,@FirstName,@LastName)";
            SqlParameter pFirstName = (FirstName == "") ? new SqlParameter("@FirstName", DBNull.Value) : new SqlParameter("@FirstName", FirstName);
            SqlParameter pLastName = (LastName == "") ? new SqlParameter("@LastName", DBNull.Value) : new SqlParameter("@LastName", LastName);
            SqlParameter pAdminID = new SqlParameter("@AdminID", AdminID);
            this.dt.Updatedata(sql, pFirstName, pLastName, pAdminID);
            this.dt.CloseConnection();
            return true;
        }
        public List<UserAdminProfile> ListAdminPrifileWithUID(int AdminID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from UserAdminProfile where AdminID=@AdminID";
            SqlParameter pAdminID = new SqlParameter("@AdminID", AdminID);
            DataTable tb = dt.DATable(sql, pAdminID);
            List<UserAdminProfile> lst = new List<UserAdminProfile>();
            foreach (DataRow r in tb.Rows)
            {
                UserAdminProfile up = new UserAdminProfile();
                up.ProfileID = (int)r["ProfileID"];
                up.AdminID = (int)r["AdminID"];
                up.FirstName = (string.IsNullOrEmpty(r["FirstName"].ToString())) ? "" : (string)r["FirstName"];
                up.LastName = (string.IsNullOrEmpty(r["LastName"].ToString())) ? "" : (string)r["LastName"];
                up.Sex = (string.IsNullOrEmpty(r["Sex"].ToString())) ? false : (Boolean)r["Sex"];
                up.Birthday = (string.IsNullOrEmpty(r["Birthday"].ToString())) ? DefaultDate : (DateTime)r["Birthday"];
                up.UserAddress = (string.IsNullOrEmpty(r["UserAddress"].ToString())) ? "" : (string)r["UserAddress"];
                up.Images = (string.IsNullOrEmpty(r["Images"].ToString())) ? 0 : (int)r["Images"];
                up.ProfileStatus = (string.IsNullOrEmpty(r["ProfileStatus"].ToString())) ? false : (Boolean)r["ProfileStatus"];
                up.DateOfStart = (DateTime)r["DateOfStart"];
                lst.Add(up);
            }
            this.dt.CloseConnection();
            return lst;
        }
    }
}
