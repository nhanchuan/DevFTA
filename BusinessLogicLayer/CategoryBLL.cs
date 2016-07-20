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
    public class CategoryBLL
    {
        DataServices dt = new DataServices();
        public DateTime defaultdate = Convert.ToDateTime("12/12/1900");
        public List<Category> ListCategoryWithID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "select * from Category where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DATable(sqlquery, pID);
            List<Category> lst = new List<Category>();
            foreach (DataRow r in tb.Rows)
            {
                Category ct = new Category();
                ct.ID = (int)r["ID"];
                ct.NameVN = (string.IsNullOrEmpty(r["NameVN"].ToString())) ? "" : (string)r["NameVN"];
                ct.NameEN = (string.IsNullOrEmpty(r["NameEN"].ToString())) ? "" : (string)r["NameEN"];
                ct.Parent = (string.IsNullOrEmpty(r["Parent"].ToString())) ? 0 : (int)r["Parent"];
                ct.ItemIndex = (string.IsNullOrEmpty(r["ItemIndex"].ToString())) ? 0 : (int)r["ItemIndex"];
                ct.Permalink = (string.IsNullOrEmpty(r["Permalink"].ToString())) ? "" : (string)r["Permalink"];
                ct.SeoTitle = (string.IsNullOrEmpty(r["SeoTitle"].ToString())) ? "" : (string)r["SeoTitle"];
                ct.CateogryImage = (string.IsNullOrEmpty(r["CateogryImage"].ToString())) ? 0 : (int)r["CateogryImage"];
                ct.CreateBy = (string.IsNullOrEmpty(r["CreateBy"].ToString())) ? 0 : (int)r["CreateBy"];
                ct.CreateDate = (DateTime)r["CreateDate"];
                ct.ModifyDate = (string.IsNullOrEmpty(r["ModifyDate"].ToString())) ? defaultdate : (DateTime)r["ModifyDate"];
                ct.ModifyBy = (string.IsNullOrEmpty(r["ModifyBy"].ToString())) ? 0 : (int)r["ModifyBy"];
                ct.MetaTitle = (string.IsNullOrEmpty(r["MetaTitle"].ToString())) ? "" : (string)r["MetaTitle"];
                ct.MetaKeywords = (string.IsNullOrEmpty(r["MetaKeywords"].ToString())) ? "" : (string)r["MetaKeywords"];
                ct.MetaDescriptions = (string.IsNullOrEmpty(r["MetaDescriptions"].ToString())) ? "" : (string)r["MetaDescriptions"];
                ct.CategoryStatus = (string.IsNullOrEmpty(r["CategoryStatus"].ToString())) ? false : (Boolean)r["CategoryStatus"];
                ct.ShowOnHome = (string.IsNullOrEmpty(r["ShowOnHome"].ToString())) ? false : (Boolean)r["ShowOnHome"];
                lst.Add(ct);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public DataTable CategoryParent()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "Exec CategoryParent";
            DataTable tb = dt.DATable(sqlquery);
            this.dt.CloseConnection();
            return tb;
        }
        public DataTable getTBSubtractCategory(int ctID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "Exec getSubtractCategory @ctID";
            SqlParameter pctID = new SqlParameter("ctID", ctID);
            DataTable tb = dt.DATable(sql, pctID);
            this.dt.CloseConnection();
            return tb;
        }
        //New Catogory
        public Boolean NewCategory(string NameVN, string NameEN, int Parent, int ItemIndex, string Permalink, string SeoTitle, int CateogryImage, int CreateBy, DateTime ModifyDate, int ModifyBy, string MetaTitle, string MetaKeywords, string MetaDescriptions, Boolean CategoryStatus, Boolean ShowOnHome)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "Exec NewCategory @NameVN,@NameEN,@Parent,@ItemIndex,@Permalink,@SeoTitle,@CateogryImage,@CreateBy,@ModifyDate,@ModifyBy,@MetaTitle,@MetaKeywords,@MetaDescriptions,@CategoryStatus,@ShowOnHome";
            SqlParameter pNameVN = new SqlParameter("@NameVN", NameVN);
            SqlParameter pNameEN = (NameEN == "") ? new SqlParameter("@NameEN", DBNull.Value) : new SqlParameter("@NameEN", NameEN);
            SqlParameter pParent = (Parent == 0) ? new SqlParameter("@Parent", DBNull.Value) : new SqlParameter("@Parent", Parent);
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            SqlParameter pPermalink = (Permalink == "") ? new SqlParameter("@Permalink", DBNull.Value) : new SqlParameter("@Permalink", Permalink);
            SqlParameter pSeoTitle = (SeoTitle == "") ? new SqlParameter("@SeoTitle", DBNull.Value) : new SqlParameter("@SeoTitle", SeoTitle);
            SqlParameter pCateogryImage = (CateogryImage == 0) ? new SqlParameter("@CateogryImage", DBNull.Value) : new SqlParameter("@CateogryImage", CateogryImage);
            SqlParameter pCreateBy = new SqlParameter("@CreateBy", CreateBy);
            SqlParameter pModifyDate = (ModifyDate.Year <= 1900) ? new SqlParameter("@ModifyDate", DBNull.Value) : new SqlParameter("@ModifyDate", ModifyDate);
            SqlParameter pModifyBy = (ModifyBy == 0) ? new SqlParameter("@ModifyBy", DBNull.Value) : new SqlParameter("@ModifyBy", ModifyBy); SqlParameter pMetaTitle = (MetaTitle == "") ? new SqlParameter("@MetaTitle", DBNull.Value) : new SqlParameter("@MetaTitle", MetaTitle);
            SqlParameter pMetaKeywords = (MetaKeywords == "") ? new SqlParameter("@MetaKeywords", DBNull.Value) : new SqlParameter("@MetaKeywords", MetaKeywords);
            SqlParameter pMetaDescriptions = (MetaDescriptions == "") ? new SqlParameter("@MetaDescriptions", DBNull.Value) : new SqlParameter("@MetaDescriptions", MetaDescriptions);
            SqlParameter pCategoryStatus = new SqlParameter("@CategoryStatus", CategoryStatus);
            SqlParameter pShowOnHome = new SqlParameter("@ShowOnHome", ShowOnHome);
            this.dt.Updatedata(sqlquery, pNameVN, pNameEN, pParent, pItemIndex, pPermalink, pSeoTitle, pCateogryImage, pCreateBy, pModifyDate, pModifyBy, pMetaTitle, pMetaKeywords, pMetaDescriptions, pCategoryStatus, pShowOnHome);
            this.dt.CloseConnection();
            return true;
        }
        //Update
        public Boolean UpdateCategory(int ID, string NameVN, string NameEN, int Parent, string Permalink, string SeoTitle, int CateogryImage, DateTime ModifyDate, int ModifyBy, string MetaTitle, string MetaKeywords, string MetaDescriptions, Boolean CategoryStatus, Boolean ShowOnHome)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "Exec UpdateCategory @ID,@NameVN,@NameEN,@Parent,@Permalink,@SeoTitle,@CateogryImage,@ModifyDate,@ModifyBy,@MetaTitle,@MetaKeywords,@MetaDescriptions,@CategoryStatus,@ShowOnHome";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pNameVN = new SqlParameter("@NameVN", NameVN);
            SqlParameter pNameEN = (NameEN == "") ? new SqlParameter("@NameEN", DBNull.Value) : new SqlParameter("@NameEN", NameEN);
            SqlParameter pParent = (Parent == 0) ? new SqlParameter("@Parent", DBNull.Value) : new SqlParameter("@Parent", Parent);
            SqlParameter pPermalink = (Permalink == "") ? new SqlParameter("@Permalink", DBNull.Value) : new SqlParameter("@Permalink", Permalink);
            SqlParameter pSeoTitle = (SeoTitle == "") ? new SqlParameter("@SeoTitle", DBNull.Value) : new SqlParameter("@SeoTitle", SeoTitle);
            SqlParameter pCateogryImage = (CateogryImage == 0) ? new SqlParameter("@CateogryImage", DBNull.Value) : new SqlParameter("@CateogryImage", CateogryImage);
            SqlParameter pModifyDate = (ModifyDate.Year <= 1900) ? new SqlParameter("@ModifyDate", DBNull.Value) : new SqlParameter("@ModifyDate", ModifyDate);
            SqlParameter pModifyBy = (ModifyBy == 0) ? new SqlParameter("@ModifyBy", DBNull.Value) : new SqlParameter("@ModifyBy", ModifyBy);
            SqlParameter pMetaTitle = (MetaTitle == "") ? new SqlParameter("@MetaTitle", DBNull.Value) : new SqlParameter("@MetaTitle", MetaTitle);
            SqlParameter pMetaKeywords = (MetaKeywords == "") ? new SqlParameter("@MetaKeywords", DBNull.Value) : new SqlParameter("@MetaKeywords", MetaKeywords);
            SqlParameter pMetaDescriptions = (MetaDescriptions == "") ? new SqlParameter("@MetaDescriptions", DBNull.Value) : new SqlParameter("@MetaDescriptions", MetaDescriptions);
            SqlParameter pCategoryStatus = new SqlParameter("@CategoryStatus", CategoryStatus);
            SqlParameter pShowOnHome = new SqlParameter("@ShowOnHome", ShowOnHome);
            this.dt.Updatedata(sqlquery, pID, pNameVN, pNameEN, pParent, pPermalink, pSeoTitle, pCateogryImage, pModifyDate, pModifyBy, pMetaTitle, pMetaKeywords, pMetaDescriptions, pCategoryStatus, pShowOnHome);
            this.dt.CloseConnection();
            return true;
        }

        public int MaxItemindexWithParent(int Parent)
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(ItemIndex) from Category where Parent=@Parent";
            SqlParameter pParent = new SqlParameter("@Parent", Parent);
            RC = dt.GetValues(sql, pParent);
            this.dt.CloseConnection();
            return RC;
        }
        public int MaxItemindexWithParentNull()
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(ItemIndex) from Category where Parent is null";
            RC = dt.GetValues(sql);
            this.dt.CloseConnection();
            return RC;
        }
        public DataTable GetCategoryPageWise(int pageindex, int pagesize)
        {
            string sql = "Exec GetCategoryPageWise @pageindex,@pagesize";
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            SqlParameter ppageindex = new SqlParameter("pageindex", pageindex);
            SqlParameter ppagesize = new SqlParameter("pagesize", pagesize);
            DataTable tb = dt.DATable(sql, ppageindex, ppagesize);
            this.dt.CloseConnection();
            return tb;
        }
        public int CountRecordPostCategory()
        {
            int rc = 0;
            string sql = "select COUNT(*) from Category";
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            rc = dt.GetValues(sql);
            this.dt.CloseConnection();
            return rc;
        }
        public DataTable getCategoryWithParent(int parentId)
        {

            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select *,(Select COUNT(*) from Category where Parent=po.ID)as childnodecount from Category po where Parent=@parentId order by po.ItemIndex asc";
            SqlParameter pparentId = new SqlParameter("@parentId", parentId);
            DataTable tb = dt.DATable(sql, pparentId);
            this.dt.CloseConnection();
            return tb;
        }
        public DataTable getCategoryWithParentNull()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select *,(Select COUNT(*) from Category where Parent=po.ID)as childnodecount  from Category po where Parent is null";
            DataTable tb = dt.DATable(sql);
            this.dt.CloseConnection();
            return tb;
        }
    }
}
