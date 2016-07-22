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
    public class SubMenuItemBLL
    {
        DataServices dt = new DataServices();
        public DataTable ListSubMenuItemByMenuID(int MenuID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "Exec ListSubMenuItemByMenuID @MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            DataTable tb = dt.DATable(sql, pMenuID);
            this.dt.CloseConnection();
            return tb;
        }
    }
}
