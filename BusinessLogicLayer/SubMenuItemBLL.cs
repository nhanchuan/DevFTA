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
        public List<SubMenuItem> ListItemByMenuIDandCategoryID(int MenuID, int CategoryID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from SubMenuItem where MenuID=@MenuID and CategoryID=@CategoryID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            DataTable tb = dt.DATable(sql, pMenuID, pCategoryID);
            List<SubMenuItem> lst = new List<SubMenuItem>();
            foreach (DataRow r in tb.Rows)
            {
                SubMenuItem itm = new SubMenuItem();
                itm.ID = (int)r["ID"];
                itm.MenuID = (string.IsNullOrEmpty(r["MenuID"].ToString())) ? 0 : (int)r["MenuID"];
                itm.CategoryID = (string.IsNullOrEmpty(r["CategoryID"].ToString())) ? 0 : (int)r["CategoryID"];
                itm.SortOrder = (string.IsNullOrEmpty(r["SortOrder"].ToString())) ? 0 : (int)r["SortOrder"];
                itm.OrtherItem = (string.IsNullOrEmpty(r["OrtherItem"].ToString())) ? "" : (string)r["OrtherItem"];
                itm.Permalink = (string.IsNullOrEmpty(r["Permalink"].ToString())) ? "" : (string)r["Permalink"];
                itm.PostID = (string.IsNullOrEmpty(r["PostID"].ToString())) ? 0 : (int)r["PostID"];
                lst.Add(itm);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<SubMenuItem> ListItemByMenuIDandPostID(int MenuID, int PostID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from SubMenuItem where MenuID=@MenuID and PostID=@PostID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            SqlParameter pPostID = new SqlParameter("@PostID", PostID);
            DataTable tb = dt.DATable(sql, pMenuID, pPostID);
            List<SubMenuItem> lst = new List<SubMenuItem>();
            foreach (DataRow r in tb.Rows)
            {
                SubMenuItem itm = new SubMenuItem();
                itm.ID = (int)r["ID"];
                itm.MenuID = (string.IsNullOrEmpty(r["MenuID"].ToString())) ? 0 : (int)r["MenuID"];
                itm.CategoryID = (string.IsNullOrEmpty(r["CategoryID"].ToString())) ? 0 : (int)r["CategoryID"];
                itm.SortOrder = (string.IsNullOrEmpty(r["SortOrder"].ToString())) ? 0 : (int)r["SortOrder"];
                itm.OrtherItem = (string.IsNullOrEmpty(r["OrtherItem"].ToString())) ? "" : (string)r["OrtherItem"];
                itm.Permalink = (string.IsNullOrEmpty(r["Permalink"].ToString())) ? "" : (string)r["Permalink"];
                itm.PostID = (string.IsNullOrEmpty(r["PostID"].ToString())) ? 0 : (int)r["PostID"];
                lst.Add(itm);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<SubMenuItem> ListItemByID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from SubMenuItem where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DATable(sql, pID);
            List<SubMenuItem> lst = new List<SubMenuItem>();
            foreach (DataRow r in tb.Rows)
            {
                SubMenuItem itm = new SubMenuItem();
                itm.ID = (int)r["ID"];
                itm.MenuID = (string.IsNullOrEmpty(r["MenuID"].ToString())) ? 0 : (int)r["MenuID"];
                itm.CategoryID = (string.IsNullOrEmpty(r["CategoryID"].ToString())) ? 0 : (int)r["CategoryID"];
                itm.SortOrder = (string.IsNullOrEmpty(r["SortOrder"].ToString())) ? 0 : (int)r["SortOrder"];
                itm.OrtherItem = (string.IsNullOrEmpty(r["OrtherItem"].ToString())) ? "" : (string)r["OrtherItem"];
                itm.Permalink = (string.IsNullOrEmpty(r["Permalink"].ToString())) ? "" : (string)r["Permalink"];
                itm.PostID = (string.IsNullOrEmpty(r["PostID"].ToString())) ? 0 : (int)r["PostID"];
                lst.Add(itm);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<SubMenuItem> ListItemBySortOrderandMenuID(int SortOrder, int MenuID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from SubMenuItem where SortOrder=@SortOrder and MenuID=@MenuID";
            SqlParameter pSortOrder = new SqlParameter("@SortOrder", SortOrder);
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            DataTable tb = dt.DATable(sql, pSortOrder, pMenuID);
            List<SubMenuItem> lst = new List<SubMenuItem>();
            foreach (DataRow r in tb.Rows)
            {
                SubMenuItem itm = new SubMenuItem();
                itm.ID = (int)r["ID"];
                itm.MenuID = (string.IsNullOrEmpty(r["MenuID"].ToString())) ? 0 : (int)r["MenuID"];
                itm.CategoryID = (string.IsNullOrEmpty(r["CategoryID"].ToString())) ? 0 : (int)r["CategoryID"];
                itm.SortOrder = (string.IsNullOrEmpty(r["SortOrder"].ToString())) ? 0 : (int)r["SortOrder"];
                itm.OrtherItem = (string.IsNullOrEmpty(r["OrtherItem"].ToString())) ? "" : (string)r["OrtherItem"];
                itm.Permalink = (string.IsNullOrEmpty(r["Permalink"].ToString())) ? "" : (string)r["Permalink"];
                itm.PostID = (string.IsNullOrEmpty(r["PostID"].ToString())) ? 0 : (int)r["PostID"];
                lst.Add(itm);
            }
            this.dt.CloseConnection();
            return lst;
        }
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
        //Add New Menu Category Item
        public Boolean AddNewSubMenuItem(int MenuID, int CategoryID, int SortOrder, string OrtherItem, string Permalink, int PostID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "insert into SubMenuItem(MenuID,CategoryID,SortOrder,OrtherItem,Permalink,PostID) values(@MenuID,@CategoryID,@SortOrder,@OrtherItem,@Permalink,@PostID)";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            SqlParameter pCategoryID = (CategoryID == 0) ? new SqlParameter("@CategoryID", DBNull.Value) : new SqlParameter("@CategoryID", CategoryID);
            SqlParameter pSortOrder = new SqlParameter("@SortOrder", SortOrder);
            SqlParameter pOrtherItem = (OrtherItem == "") ? new SqlParameter("@OrtherItem", DBNull.Value) : new SqlParameter("@OrtherItem", OrtherItem);
            SqlParameter pPermalink = (Permalink == "") ? new SqlParameter("@Permalink", DBNull.Value) : new SqlParameter("@Permalink", Permalink);
            SqlParameter pPostID = (PostID == 0) ? new SqlParameter("@PostID", DBNull.Value) : new SqlParameter("@PostID", PostID);
            this.dt.Updatedata(sql, pMenuID, pCategoryID, pSortOrder, pOrtherItem, pPermalink, pPostID);
            this.dt.CloseConnection();
            return true;
        }
        ////====================
        public int MaxSortOrderByMenuID(int MenuID)
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(SortOrder) from SubMenuItem where MenuID=@MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            RC = dt.GetValues(sql, pMenuID);
            this.dt.CloseConnection();
            return RC;
        }
        //Delete
        public Boolean DeleteByID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "delete from SubMenuItem where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            this.dt.Updatedata(sql, pID);
            this.dt.CloseConnection();
            return true;
        }
        //
        public int MaxItemindexLK(int SortOrder, int MenuID)
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(SortOrder) from SubMenuItem where MenuID=@MenuID and SortOrder<@SortOrder";
            SqlParameter pSortOrder = new SqlParameter("@SortOrder", SortOrder);
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            RC = dt.GetValues(sql, pSortOrder, pMenuID);
            this.dt.CloseConnection();
            return RC;
        }
        public int MinItemindexLK(int SortOrder, int MenuID)
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select min(SortOrder) from SubMenuItem where MenuID=@MenuID and SortOrder>@SortOrder";
            SqlParameter pSortOrder = new SqlParameter("@SortOrder", SortOrder);
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            RC = dt.GetValues(sql, pSortOrder, pMenuID);
            this.dt.CloseConnection();
            return RC;
        }
        //
        //Update Index Item
        public Boolean UpdateIndexItem(int SortOrder, int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update SubMenuItem set SortOrder=@SortOrder where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pSortOrder = new SqlParameter("@SortOrder", SortOrder);
            this.dt.Updatedata(sql, pID, pSortOrder);
            this.dt.CloseConnection();
            return true;
        }
    }
}
