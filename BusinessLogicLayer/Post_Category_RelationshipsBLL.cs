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
    public class Post_Category_RelationshipsBLL
    {
        DataServices dt = new DataServices();

        /// <summary>
        /// New Post_Category_Relationships
        /// </summary>
        /// <param name="PostID">Post ID</param>
        /// <param name="CategoryID">Category ID </param>
        /// <returns></returns>
        public Boolean NewPost_Category_Relationships(int PostID, int CategoryID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "insert into Post_Category_Relationships(PostID,CategoryID) values(@PostID,@CategoryID)";
            SqlParameter pPostID = new SqlParameter("@PostID", PostID);
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            this.dt.Updatedata(sqlquery, pPostID, pCategoryID);
            this.dt.CloseConnection();
            return true;
        }
        public List<Post_Category_Relationships> getCategoryWithPostId(int PostID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "select * from Post_Category_Relationships where PostID=@PostID";
            SqlParameter pPostID = new SqlParameter("@PostID", PostID);
            DataTable tb = dt.DATable(sqlquery, pPostID);
            List<Post_Category_Relationships> lst = new List<Post_Category_Relationships>();
            foreach (DataRow r in tb.Rows)
            {
                Post_Category_Relationships pr = new Post_Category_Relationships();
                pr.PostID = (string.IsNullOrEmpty(r["PostID"].ToString())) ? 0 : (int)r["PostID"];
                pr.CategoryID = (string.IsNullOrEmpty(r["CategoryID"].ToString())) ? 0 : (int)r["CategoryID"];
                lst.Add(pr);
            }
            this.dt.CloseConnection();
            return lst;
        }
        //Delete
        public Boolean DeleteWithPostID(int PostID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "delete from Post_Category_Relationships where PostID=@PostID";
            SqlParameter pPostID = new SqlParameter("@PostID", PostID);
            this.dt.Updatedata(sqlquery, pPostID);
            this.dt.CloseConnection();
            return true;
        }
        public Boolean DeleteWithCategoryID(int CategoryID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "delete from Post_Category_Relationships where CategoryID=@CategoryID";
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            this.dt.Updatedata(sqlquery, pCategoryID);
            this.dt.CloseConnection();
            return true;
        }
    }
}
