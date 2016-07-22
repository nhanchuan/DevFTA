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
    public class MainMenuBLL
    {
        DataServices dt = new DataServices();
        public List<MainMenu> ListMenuItems()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from MainMenu order by ItemIndex asc";
            DataTable tb = dt.DATable(sql);
            List<MainMenu> lst = new List<MainMenu>();
            foreach (DataRow r in tb.Rows)
            {
                MainMenu menu = new MainMenu();
                menu.MenuID = (int)r["MenuID"];
                menu.ItemName = (string.IsNullOrEmpty(r["ItemName"].ToString())) ? "" : (string)r["ItemName"];
                menu.Permalink = (string.IsNullOrEmpty(r["Permalink"].ToString())) ? "" : (string)r["Permalink"];
                menu.ItemIndex = (int)r["ItemIndex"];
                menu.MenuStatus = (string.IsNullOrEmpty(r["MenuStatus"].ToString())) ? false : (Boolean)r["MenuStatus"];
                lst.Add(menu);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<MainMenu> ListMenuItemsWithMenuID(int MenuID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from MainMenu where MenuID=@MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            DataTable tb = dt.DATable(sql, pMenuID);
            List<MainMenu> lst = new List<MainMenu>();
            foreach (DataRow r in tb.Rows)
            {
                MainMenu menu = new MainMenu();
                menu.MenuID = (int)r["MenuID"];
                menu.ItemName = (string.IsNullOrEmpty(r["ItemName"].ToString())) ? "" : (string)r["ItemName"];
                menu.Permalink = (string.IsNullOrEmpty(r["Permalink"].ToString())) ? "" : (string)r["Permalink"];
                menu.ItemIndex = (int)r["ItemIndex"];
                menu.MenuStatus = (string.IsNullOrEmpty(r["MenuStatus"].ToString())) ? false : (Boolean)r["MenuStatus"];
                lst.Add(menu);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<MainMenu> ListMenuItemsWithIndex(int ItemIndex)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from MainMenu where ItemIndex=@ItemIndex";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            DataTable tb = dt.DATable(sql, pItemIndex);
            List<MainMenu> lst = new List<MainMenu>();
            foreach (DataRow r in tb.Rows)
            {
                MainMenu menu = new MainMenu();
                menu.MenuID = (int)r["MenuID"];
                menu.ItemName = (string.IsNullOrEmpty(r["ItemName"].ToString())) ? "" : (string)r["ItemName"];
                menu.Permalink = (string.IsNullOrEmpty(r["Permalink"].ToString())) ? "" : (string)r["Permalink"];
                menu.ItemIndex = (int)r["ItemIndex"];
                menu.MenuStatus = (string.IsNullOrEmpty(r["MenuStatus"].ToString())) ? false : (Boolean)r["MenuStatus"];
                lst.Add(menu);
            }
            this.dt.CloseConnection();
            return lst;
        }
        //Create
        public Boolean NewMainMenu(string ItemName, string Permalink, int ItemIndex, Boolean MenuStatus)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "insert into MainMenu(ItemName,Permalink,ItemIndex,MenuStatus) values(@ItemName,@Permalink,@ItemIndex,@MenuStatus)";
            SqlParameter pItemName = (ItemName == "") ? new SqlParameter("@ItemName", DBNull.Value) : new SqlParameter("@ItemName", ItemName);
            SqlParameter pPermalink = (Permalink == "") ? new SqlParameter("@Permalink", DBNull.Value) : new SqlParameter("@Permalink", Permalink);
            SqlParameter pItemIndex = (ItemIndex == 0) ? new SqlParameter("@ItemIndex", DBNull.Value) : new SqlParameter("@ItemIndex", ItemIndex);
            SqlParameter pMenuStatus = new SqlParameter("@MenuStatus", MenuStatus);
            this.dt.Updatedata(sql, pItemName, pPermalink, pItemIndex, pMenuStatus);
            this.dt.CloseConnection();
            return true;
        }
        //Update
        public Boolean UpdateMainMenu(int MenuID, string ItemName, string Permalink, Boolean MenuStatus)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update MainMenu set ItemName=@ItemName, Permalink=@Permalink, MenuStatus=@MenuStatus where MenuID=@MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            SqlParameter pItemName = (ItemName == "") ? new SqlParameter("@ItemName", DBNull.Value) : new SqlParameter("@ItemName", ItemName);
            SqlParameter pPermalink = (Permalink == "") ? new SqlParameter("@Permalink", DBNull.Value) : new SqlParameter("@Permalink", Permalink);
            SqlParameter pMenuStatus = new SqlParameter("@MenuStatus", MenuStatus);
            this.dt.Updatedata(sql, pMenuID, pItemName, pPermalink, pMenuStatus);
            this.dt.CloseConnection();
            return true;
        }
        public int MaxItemindex()
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(ItemIndex) from MainMenu";
            RC = dt.GetValues(sql);
            this.dt.CloseConnection();
            return RC;
        }
        public int MinItemindex()
        {
            int RC = 0;
            
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select min(ItemIndex) from MainMenu";
            RC = dt.GetValues(sql);
            this.dt.CloseConnection();
            return RC;
        }
        public int MaxItemindexLK(int ItemIndex)
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(ItemIndex) from MainMenu where ItemIndex<@ItemIndex";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            RC = dt.GetValues(sql, pItemIndex);
            this.dt.CloseConnection();
            return RC;
        }
        public int MinItemindexLK(int ItemIndex)
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select min(ItemIndex) from MainMenu where ItemIndex>@ItemIndex";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            RC = dt.GetValues(sql, pItemIndex);
            this.dt.CloseConnection();
            return RC;
        }
        //Update Status
        public Boolean UpdateStatus(int MenuID, Boolean MenuStatus)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update MainMenu set MenuStatus=@MenuStatus where MenuID=@MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            SqlParameter pMenuStatus = new SqlParameter("@MenuStatus", MenuStatus);
            this.dt.Updatedata(sql, pMenuID, pMenuStatus);
            this.dt.CloseConnection();
            return true;
        }
    }
}
