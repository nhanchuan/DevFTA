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
        
    }
}
