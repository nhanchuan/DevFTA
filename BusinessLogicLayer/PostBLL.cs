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
    }
}
