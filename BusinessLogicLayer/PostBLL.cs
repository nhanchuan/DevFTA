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
        public Boolean NewPost(string TitleVN, string TitleEN, string PostContentVN, string PostContentEN, int CreateBy, DateTime ModifyDate, int ModifyBy, string MetaTitle, string MetaKeywords, string MetaDescriptions, int PostStatus, Boolean TopHot, int PostImages, DateTime PostTime, string PostCode)
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
            this.dt.Updatedata(sqlquery, pTitleVN, pTitleEN, pPostContentVN, pPostContentEN, pCreateBy, pModifyDate, pModifyBy, pMetaTitle, pMetaKeywords, pMetaDescriptions, pPostStatus, pTopHot, pPostImages);
            this.dt.CloseConnection();
            return true;

        }
    }
}
