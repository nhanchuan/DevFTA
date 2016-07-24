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
    public class PostBLL
    {
        DataServices dt = new DataServices();
        public DateTime defaultdate = Convert.ToDateTime("12/12/1900");
        public List<Post> ListPosByID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "select * from Post where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DATable(sqlquery, pID);
            List<Post> lst = new List<Post>();
            foreach (DataRow r in tb.Rows)
            {
                Post p = new Post();
                p.ID = (int)r["ID"];
                p.TitleVN = (string.IsNullOrEmpty(r["TitleVN"].ToString())) ? "" : (string)r["TitleVN"];
                p.TitleEN = (string.IsNullOrEmpty(r["TitleEN"].ToString())) ? "" : (string)r["TitleEN"];
                p.PostContentVN = (string.IsNullOrEmpty(r["PostContentVN"].ToString())) ? "" : (string)r["PostContentVN"];
                p.PostContentEN = (string.IsNullOrEmpty(r["PostContentEN"].ToString())) ? "" : (string)r["PostContentEN"];
                p.CreateBy = (int)r["CreateBy"];
                p.CreateDate = (DateTime)r["CreateDate"];
                p.ModifyDate = (string.IsNullOrEmpty(r["ModifyDate"].ToString())) ? defaultdate : (DateTime)r["ModifyDate"];
                p.ModifyBy = (string.IsNullOrEmpty(r["ModifyBy"].ToString())) ? 0 : (int)r["ModifyBy"];
                p.MetaTitle = (string.IsNullOrEmpty(r["MetaTitle"].ToString())) ? "" : (string)r["MetaTitle"];
                p.MetaKeywords = (string.IsNullOrEmpty(r["MetaKeywords"].ToString())) ? "" : (string)r["MetaKeywords"];
                p.MetaDescriptions = (string.IsNullOrEmpty(r["MetaDescriptions"].ToString())) ? "" : (string)r["MetaDescriptions"];
                p.PostStatus = (string.IsNullOrEmpty(r["PostStatus"].ToString())) ? false : (Boolean)r["PostStatus"];
                p.ViewCount = (string.IsNullOrEmpty(r["ViewCount"].ToString())) ? 0 : (int)r["ViewCount"];
                p.TopHot = (string.IsNullOrEmpty(r["TopHot"].ToString())) ? false : (Boolean)r["TopHot"];
                p.PostImages = (string.IsNullOrEmpty(r["PostImages"].ToString())) ? 0 : (int)r["PostImages"];
                p.PostTime = (string.IsNullOrEmpty(r["PostTime"].ToString())) ? defaultdate : (DateTime)r["PostTime"];
                p.PostCode = (string.IsNullOrEmpty(r["PostCode"].ToString())) ? "" : (string)r["PostCode"];
                lst.Add(p);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<Post> ListPostWithPostCode(string PostCode)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "select * from Post where PostCode=@PostCode";
            SqlParameter pPostCode = new SqlParameter("@PostCode", PostCode);
            DataTable tb = dt.DATable(sqlquery, pPostCode);
            List<Post> lst = new List<Post>();
            foreach(DataRow r in tb.Rows)
            {
                Post p = new Post();
                p.ID = (int)r["ID"];
                p.TitleVN = (string.IsNullOrEmpty(r["TitleVN"].ToString())) ? "" : (string)r["TitleVN"];
                p.TitleEN = (string.IsNullOrEmpty(r["TitleEN"].ToString())) ? "" : (string)r["TitleEN"];
                p.PostContentVN = (string.IsNullOrEmpty(r["PostContentVN"].ToString())) ? "" : (string)r["PostContentVN"];
                p.PostContentEN = (string.IsNullOrEmpty(r["PostContentEN"].ToString())) ? "" : (string)r["PostContentEN"];
                p.CreateBy = (int)r["CreateBy"];
                p.CreateDate = (DateTime)r["CreateDate"];
                p.ModifyDate = (string.IsNullOrEmpty(r["ModifyDate"].ToString())) ? defaultdate : (DateTime)r["ModifyDate"];
                p.ModifyBy = (string.IsNullOrEmpty(r["ModifyBy"].ToString())) ? 0 : (int)r["ModifyBy"];
                p.MetaTitle = (string.IsNullOrEmpty(r["MetaTitle"].ToString())) ? "" : (string)r["MetaTitle"];
                p.MetaKeywords = (string.IsNullOrEmpty(r["MetaKeywords"].ToString())) ? "" : (string)r["MetaKeywords"];
                p.MetaDescriptions = (string.IsNullOrEmpty(r["MetaDescriptions"].ToString())) ? "" : (string)r["MetaDescriptions"];
                p.PostStatus = (string.IsNullOrEmpty(r["PostStatus"].ToString())) ? false : (Boolean)r["PostStatus"];
                p.ViewCount = (string.IsNullOrEmpty(r["ViewCount"].ToString())) ? 0 : (int)r["ViewCount"];
                p.TopHot = (string.IsNullOrEmpty(r["TopHot"].ToString())) ? false : (Boolean)r["TopHot"];
                p.PostImages = (string.IsNullOrEmpty(r["PostImages"].ToString())) ? 0 : (int)r["PostImages"];
                p.PostTime = (string.IsNullOrEmpty(r["PostTime"].ToString())) ? defaultdate : (DateTime)r["PostTime"];
                p.PostCode = (string.IsNullOrEmpty(r["PostCode"].ToString())) ? "" : (string)r["PostCode"];
                lst.Add(p);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<Post> ListAllPost()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "select * from Post";
            DataTable tb = dt.DATable(sqlquery);
            List<Post> lst = new List<Post>();
            foreach (DataRow r in tb.Rows)
            {
                Post p = new Post();
                p.ID = (int)r["ID"];
                p.TitleVN = (string.IsNullOrEmpty(r["TitleVN"].ToString())) ? "" : (string)r["TitleVN"];
                p.TitleEN = (string.IsNullOrEmpty(r["TitleEN"].ToString())) ? "" : (string)r["TitleEN"];
                p.PostContentVN = (string.IsNullOrEmpty(r["PostContentVN"].ToString())) ? "" : (string)r["PostContentVN"];
                p.PostContentEN = (string.IsNullOrEmpty(r["PostContentEN"].ToString())) ? "" : (string)r["PostContentEN"];
                p.CreateBy = (int)r["CreateBy"];
                p.CreateDate = (DateTime)r["CreateDate"];
                p.ModifyDate = (string.IsNullOrEmpty(r["ModifyDate"].ToString())) ? defaultdate : (DateTime)r["ModifyDate"];
                p.ModifyBy = (string.IsNullOrEmpty(r["ModifyBy"].ToString())) ? 0 : (int)r["ModifyBy"];
                p.MetaTitle = (string.IsNullOrEmpty(r["MetaTitle"].ToString())) ? "" : (string)r["MetaTitle"];
                p.MetaKeywords = (string.IsNullOrEmpty(r["MetaKeywords"].ToString())) ? "" : (string)r["MetaKeywords"];
                p.MetaDescriptions = (string.IsNullOrEmpty(r["MetaDescriptions"].ToString())) ? "" : (string)r["MetaDescriptions"];
                p.PostStatus = (string.IsNullOrEmpty(r["PostStatus"].ToString())) ? false : (Boolean)r["PostStatus"];
                p.ViewCount = (string.IsNullOrEmpty(r["ViewCount"].ToString())) ? 0 : (int)r["ViewCount"];
                p.TopHot = (string.IsNullOrEmpty(r["TopHot"].ToString())) ? false : (Boolean)r["TopHot"];
                p.PostImages = (string.IsNullOrEmpty(r["PostImages"].ToString())) ? 0 : (int)r["PostImages"];
                p.PostTime = (string.IsNullOrEmpty(r["PostTime"].ToString())) ? defaultdate : (DateTime)r["PostTime"];
                p.PostCode = (string.IsNullOrEmpty(r["PostCode"].ToString())) ? "" : (string)r["PostCode"];
                lst.Add(p);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<Post> ListAllPostinACtive()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "select * from Post where PostStatus<>0";
            DataTable tb = dt.DATable(sqlquery);
            List<Post> lst = new List<Post>();
            foreach (DataRow r in tb.Rows)
            {
                Post p = new Post();
                p.ID = (int)r["ID"];
                p.TitleVN = (string.IsNullOrEmpty(r["TitleVN"].ToString())) ? "" : (string)r["TitleVN"];
                p.TitleEN = (string.IsNullOrEmpty(r["TitleEN"].ToString())) ? "" : (string)r["TitleEN"];
                p.PostContentVN = (string.IsNullOrEmpty(r["PostContentVN"].ToString())) ? "" : (string)r["PostContentVN"];
                p.PostContentEN = (string.IsNullOrEmpty(r["PostContentEN"].ToString())) ? "" : (string)r["PostContentEN"];
                p.CreateBy = (int)r["CreateBy"];
                p.CreateDate = (DateTime)r["CreateDate"];
                p.ModifyDate = (string.IsNullOrEmpty(r["ModifyDate"].ToString())) ? defaultdate : (DateTime)r["ModifyDate"];
                p.ModifyBy = (string.IsNullOrEmpty(r["ModifyBy"].ToString())) ? 0 : (int)r["ModifyBy"];
                p.MetaTitle = (string.IsNullOrEmpty(r["MetaTitle"].ToString())) ? "" : (string)r["MetaTitle"];
                p.MetaKeywords = (string.IsNullOrEmpty(r["MetaKeywords"].ToString())) ? "" : (string)r["MetaKeywords"];
                p.MetaDescriptions = (string.IsNullOrEmpty(r["MetaDescriptions"].ToString())) ? "" : (string)r["MetaDescriptions"];
                p.PostStatus = (string.IsNullOrEmpty(r["PostStatus"].ToString())) ? false : (Boolean)r["PostStatus"];
                p.ViewCount = (string.IsNullOrEmpty(r["ViewCount"].ToString())) ? 0 : (int)r["ViewCount"];
                p.TopHot = (string.IsNullOrEmpty(r["TopHot"].ToString())) ? false : (Boolean)r["TopHot"];
                p.PostImages = (string.IsNullOrEmpty(r["PostImages"].ToString())) ? 0 : (int)r["PostImages"];
                p.PostTime = (string.IsNullOrEmpty(r["PostTime"].ToString())) ? defaultdate : (DateTime)r["PostTime"];
                p.PostCode = (string.IsNullOrEmpty(r["PostCode"].ToString())) ? "" : (string)r["PostCode"];
                lst.Add(p);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public Boolean NewPost(string TitleVN, string TitleEN, string PostContentVN, string PostContentEN, int CreateBy, DateTime ModifyDate, int ModifyBy, string MetaTitle, string MetaKeywords, string MetaDescriptions, Boolean PostStatus, Boolean TopHot, int PostImages, DateTime PostTime, string PostCode)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "Exec NewPost @TitleVN,@TitleEN,@PostContentVN,@PostContentEN,@CreateBy,@ModifyDate,@ModifyBy,@MetaTitle,@MetaKeywords,@MetaDescriptions,@PostStatus,@TopHot,@PostImages,@PostTime,@PostCode";
            SqlParameter pTitleVN = (TitleVN == "") ? new SqlParameter("@TitleVN", DBNull.Value) : new SqlParameter("@TitleVN", TitleVN);
            SqlParameter pTitleEN = (TitleEN == "") ? new SqlParameter("@TitleEN", DBNull.Value) : new SqlParameter("@TitleEN", TitleEN);
            SqlParameter pPostContentVN = (PostContentVN == "") ? new SqlParameter("@PostContentVN", DBNull.Value) : new SqlParameter("@PostContentVN", PostContentVN);
            SqlParameter pPostContentEN = (PostContentEN == "") ? new SqlParameter("@PostContentEN", DBNull.Value) : new SqlParameter("@PostContentEN", PostContentEN);
            SqlParameter pCreateBy = (CreateBy == 0) ? new SqlParameter("@CreateBy", DBNull.Value) : new SqlParameter("@CreateBy", CreateBy);
            SqlParameter pModifyDate = (ModifyDate.Year <= 1900) ? new SqlParameter("@ModifyDate", DBNull.Value) : new SqlParameter("@ModifyDate", ModifyDate);
            SqlParameter pModifyBy = (ModifyBy == 0) ? new SqlParameter("@ModifyBy", DBNull.Value) : new SqlParameter("@ModifyBy", ModifyBy);
            SqlParameter pMetaTitle = (MetaTitle == "") ? new SqlParameter("@MetaTitle", DBNull.Value) : new SqlParameter("@MetaTitle", MetaTitle);
            SqlParameter pMetaKeywords = (MetaKeywords == "") ? new SqlParameter("@MetaKeywords", DBNull.Value) : new SqlParameter("@MetaKeywords", MetaKeywords);
            SqlParameter pMetaDescriptions = (MetaDescriptions == "") ? new SqlParameter("@MetaDescriptions", DBNull.Value) : new SqlParameter("@MetaDescriptions", MetaDescriptions);
            SqlParameter pPostStatus = new SqlParameter("@PostStatus", PostStatus);
            SqlParameter pTopHot = new SqlParameter("@TopHot", TopHot);
            SqlParameter pPostImages = (PostImages == 0) ? new SqlParameter("@PostImages", DBNull.Value) : new SqlParameter("@PostImages", PostImages);
            SqlParameter pPostTime = (PostTime.Year <= 1900) ? new SqlParameter("@PostTime", DBNull.Value) : new SqlParameter("@PostTime", PostTime);
            SqlParameter pPostCode = (PostCode == "") ? new SqlParameter("@PostCode", DBNull.Value) : new SqlParameter("@PostCode", PostCode);
            this.dt.Updatedata(sqlquery, pTitleVN, pTitleEN, pPostContentVN, pPostContentEN, pCreateBy, pModifyDate, pModifyBy, pMetaTitle, pMetaKeywords, pMetaDescriptions, pPostStatus, pTopHot, pPostImages, pPostTime, pPostCode);
            this.dt.CloseConnection();
            return true;
        }
        //UPDATE
        public Boolean UpdatePost(int ID, string TitleVN, string TitleEN, string PostContentVN, string PostContentEN, DateTime ModifyDate, int ModifyBy, string MetaTitle, string MetaKeywords, string MetaDescriptions, Boolean PostStatus, Boolean TopHot, int PostImages, DateTime PostTime)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "Exec UpdatePost @ID,@TitleVN,@TitleEN,@PostContentVN,@PostContentEN,@ModifyDate,@ModifyBy,@MetaTitle,@MetaKeywords,@MetaDescriptions,@PostStatus,@TopHot,@PostImages,@PostTime";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pTitleVN = (TitleVN == "") ? new SqlParameter("@TitleVN", DBNull.Value) : new SqlParameter("@TitleVN", TitleVN);
            SqlParameter pTitleEN = (TitleEN == "") ? new SqlParameter("@TitleEN", DBNull.Value) : new SqlParameter("@TitleEN", TitleEN);
            SqlParameter pPostContentVN = (PostContentVN == "") ? new SqlParameter("@PostContentVN", DBNull.Value) : new SqlParameter("@PostContentVN", PostContentVN);
            SqlParameter pPostContentEN = (PostContentEN == "") ? new SqlParameter("@PostContentEN", DBNull.Value) : new SqlParameter("@PostContentEN", PostContentEN);
            SqlParameter pModifyDate = (ModifyDate.Year <= 1900) ? new SqlParameter("@ModifyDate", DBNull.Value) : new SqlParameter("@ModifyDate", ModifyDate);
            SqlParameter pModifyBy = (ModifyBy == 0) ? new SqlParameter("@ModifyBy", DBNull.Value) : new SqlParameter("@ModifyBy", ModifyBy);
            SqlParameter pMetaTitle = (MetaTitle == "") ? new SqlParameter("@MetaTitle", DBNull.Value) : new SqlParameter("@MetaTitle", MetaTitle);
            SqlParameter pMetaKeywords = (MetaKeywords == "") ? new SqlParameter("@MetaKeywords", DBNull.Value) : new SqlParameter("@MetaKeywords", MetaKeywords);
            SqlParameter pMetaDescriptions = (MetaDescriptions == "") ? new SqlParameter("@MetaDescriptions", DBNull.Value) : new SqlParameter("@MetaDescriptions", MetaDescriptions);
            SqlParameter pPostStatus = new SqlParameter("@PostStatus", PostStatus);
            SqlParameter pTopHot = new SqlParameter("@TopHot", TopHot);
            SqlParameter pPostImages = (PostImages == 0) ? new SqlParameter("@PostImages", DBNull.Value) : new SqlParameter("@PostImages", PostImages);
            SqlParameter pPostTime = (PostTime.Year <= 1900) ? new SqlParameter("@PostTime", DBNull.Value) : new SqlParameter("@PostTime", PostTime);
            this.dt.Updatedata(sqlquery, pID, pTitleVN, pTitleEN, pPostContentVN, pPostContentEN, pModifyDate, pModifyBy, pMetaTitle, pMetaKeywords, pMetaDescriptions, pPostStatus, pTopHot, pPostImages, pPostTime);
            this.dt.CloseConnection();
            return true;
        }
        public DataTable GetPostsPageWise(int PageIndex, int PageSize)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "Exec GetPostsPageWise @PageIndex,@PageSize";
            SqlParameter paramPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("PageSize", PageSize);
            DataTable tb = dt.DATable(sqlquery, paramPageIndex, paramPageSize);
            this.dt.CloseConnection();
            return tb;
        }
        public int RecordCountPosts() //COUNT ROW IN TABLE IMAGES
        {
            int RC = 0;

            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from Post";
            RC = dt.GetValues(sql);
            this.dt.CloseConnection();
            return RC;
        }
        //Update Post status
        public Boolean UpdatePostStatus(int ID, Boolean PostStatus)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update Post set PostStatus=@PostStatus where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pPostStatus = new SqlParameter("@PostStatus", PostStatus);
            this.dt.Updatedata(sql, pID, pPostStatus);
            this.dt.CloseConnection();
            return true;
        }
        //Update Post Top Hot
        public Boolean UpdatePostTopHot(int ID, Boolean TopHot)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update Post set TopHot=@TopHot where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pTopHot = new SqlParameter("@TopHot", TopHot);
            this.dt.Updatedata(sql, pID, pTopHot);
            this.dt.CloseConnection();
            return true;
        }
        //GetSearchKeyPostsPageWise
        public DataTable GetSearchKeyPostsPageWise(int PageIndex, int PageSize, string keysearch)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "Exec GetSearchKeyPostsPageWise @PageIndex,@PageSize,@keysearch";
            SqlParameter paramPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pkeysearch = new SqlParameter("@keysearch", keysearch);
            DataTable tb = dt.DATable(sqlquery, paramPageIndex, paramPageSize, pkeysearch);
            this.dt.CloseConnection();
            return tb;
        }
        public int RecordCountKeySeachPosts(string keysearch) //COUNT ROW IN TABLE IMAGES
        {
            int RC = 0;

            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from Post where (CONTAINS(TitleVN,@keysearch) OR CONTAINS(TitleEN, @keysearch) OR CONTAINS(MetaTitle, @keysearch) OR CONTAINS(MetaKeywords, @keysearch) OR CONTAINS(MetaDescriptions, @keysearch))";
            SqlParameter pkeysearch = new SqlParameter("@keysearch", keysearch);
            RC = dt.GetValues(sql, pkeysearch);
            this.dt.CloseConnection();
            return RC;
        }
        //===========================================================
        //FRONT END CODE
        //===========================================================
        public DataTable GetListPostsByCategoryIDPageWise(int PageIndex, int PageSize, int CategoryID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "Exec GetListPostsByCategoryIDPageWise @PageIndex,@PageSize,@CategoryID";
            SqlParameter pPageIndex = new SqlParameter("@PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("@PageSize", PageSize);
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            DataTable tb = dt.DATable(sqlquery, pPageIndex, pPageSize, pCategoryID);
            this.dt.CloseConnection();
            return tb;
        }
        public int CountListPostsByCategoryIDPageWise(int CategoryID)
        {
            int RC = 0;

            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(pot.ID) from Post pot full outer join Post_Category_Relationships pcr on pot.ID=pcr.PostID";
            sql += " ";
            sql += "where pot.ID is not null and pcr.CategoryID=@CategoryID and pot.PostStatus<>0 and pot.PostTime <=getdate()";
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            RC = dt.GetValues(sql, pCategoryID);
            this.dt.CloseConnection();
            return RC;
        }
        public DataTable WidgetIndexNews(int CategoryID, int Itemview)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "Exec WidgetIndexNews @CategoryID,@Itemview";
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            SqlParameter pItemview = new SqlParameter("@Itemview", Itemview);
            DataTable tb = dt.DATable(sqlquery, pCategoryID, pItemview);
            this.dt.CloseConnection();
            return tb;
        }
    }
}
