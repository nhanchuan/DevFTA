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
            SqlParameter pModifyBy = (ModifyBy == 0) ? new SqlParameter("@ModifyBy", DBNull.Value) : new SqlParameter("@ModifyBy", ModifyBy);            SqlParameter pMetaTitle = (MetaTitle == "") ? new SqlParameter("@MetaTitle", DBNull.Value) : new SqlParameter("@MetaTitle", MetaTitle);
            SqlParameter pMetaKeywords = (MetaKeywords == "") ? new SqlParameter("@MetaKeywords", DBNull.Value) : new SqlParameter("@MetaKeywords", MetaKeywords);
            SqlParameter pMetaDescriptions = (MetaDescriptions == "") ? new SqlParameter("@MetaDescriptions", DBNull.Value) : new SqlParameter("@MetaDescriptions", MetaDescriptions);
            SqlParameter pCategoryStatus = new SqlParameter("@CategoryStatus", CategoryStatus);
            SqlParameter pShowOnHome = new SqlParameter("@ShowOnHome", ShowOnHome);
            this.dt.Updatedata(sqlquery, pNameVN, pNameEN, pParent, pItemIndex, pPermalink, pSeoTitle, pCateogryImage, pCreateBy, pModifyDate, pModifyBy, pMetaTitle, pMetaKeywords, pMetaDescriptions, pCategoryStatus, pShowOnHome);
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
