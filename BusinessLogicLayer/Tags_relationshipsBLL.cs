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
    public class Tags_relationshipsBLL
    {
        DataServices dt = new DataServices();
        public List<Tags_relationships> ListAllTagsRe()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquerry = "select * from Tags_relationships";
            DataTable tb = dt.DATable(sqlquerry);
            List<Tags_relationships> lst = new List<Tags_relationships>();
            foreach (DataRow r in tb.Rows)
            {
                Tags_relationships tgr = new Tags_relationships();
                tgr.PostID = (int)r["PostID"];
                tgr.TagsID = (int)r["TagsID"];
                lst.Add(tgr);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<Tags_relationships> getTagsWithPostID(int postID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquerry = "select * from Tags_relationships where PostID=@postID";
            SqlParameter ppostID = new SqlParameter("@postID", postID);
            DataTable tb = dt.DATable(sqlquerry, ppostID);
            List<Tags_relationships> lst = new List<Tags_relationships>();
            foreach (DataRow r in tb.Rows)
            {
                Tags_relationships tr = new Tags_relationships();
                tr.PostID = (string.IsNullOrEmpty(r["PostID"].ToString())) ? 0 : (int)r["PostID"];
                tr.TagsID = (string.IsNullOrEmpty(r["TagsID"].ToString())) ? 0 : (int)r["TagsID"];
                lst.Add(tr);
            }
            this.dt.CloseConnection();
            return lst;
        }
        //New
        public Boolean NewTags_relationships(int PostID, int TagsID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquerry = "insert into Tags_relationships(PostID,TagsID) values(@PostID,@TagsID)";
            SqlParameter pPostID = new SqlParameter("@PostID", PostID);
            SqlParameter pTagsID = new SqlParameter("@TagsID", TagsID);
            this.dt.Updatedata(sqlquerry, pPostID, pTagsID);
            return true;
        }
        //Delete
        public Boolean DeleteWithPostID(int PostID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "delete from Tags_relationships where PostID=@PostID";
            SqlParameter pPostID = new SqlParameter("@PostID", PostID);
            this.dt.Updatedata(sqlquery, pPostID);
            this.dt.CloseConnection();
            return true;
        }
    }
}
