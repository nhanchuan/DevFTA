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
    public class ImagesBLL
    {
        DataServices dt = new DataServices();
        public List<Images> ListWithImagesName(string ImagesName)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Images where ImagesName=@ImagesName";
            SqlParameter pImagesName = new SqlParameter("@ImagesName", ImagesName);
            DataTable tb = dt.DATable(sql, pImagesName);
            List<Images> lst = new List<Images>();
            foreach (DataRow r in tb.Rows)
            {
                Images im = new Images();
                im.ID = (int)r["ID"];
                im.ImagesName = (string.IsNullOrEmpty(r["ImagesName"].ToString())) ? "" : (string)r["ImagesName"];
                im.ImagesUrl = (string.IsNullOrEmpty(r["ImagesUrl"].ToString())) ? "" : (string)r["ImagesUrl"];
                im.UserUpload = (string.IsNullOrEmpty(r["UserUpload"].ToString())) ? 0 : (int)r["UserUpload"];
                im.DateOfStart = (DateTime)r["DateOfStart"];
                lst.Add(im);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<Images> ListWithID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Images where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DATable(sql, pID);
            List<Images> lst = new List<Images>();
            foreach (DataRow r in tb.Rows)
            {
                Images im = new Images();
                im.ID = (int)r["ID"];
                im.ImagesName = (string.IsNullOrEmpty(r["ImagesName"].ToString())) ? "" : (string)r["ImagesName"];
                im.ImagesUrl = (string.IsNullOrEmpty(r["ImagesUrl"].ToString())) ? "" : (string)r["ImagesUrl"];
                im.UserUpload = (string.IsNullOrEmpty(r["UserUpload"].ToString())) ? 0 : (int)r["UserUpload"];
                im.DateOfStart = (DateTime)r["DateOfStart"];
                lst.Add(im);
            }
            this.dt.CloseConnection();
            return lst;
        }
        // THU VIEN HINH ANH ==================================================================
        public DataTable GetImagesPageWise(int PageIndex, int PageSize)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "Exec GetImagesPageWise @PageIndex,@PageSize";
            SqlParameter paramPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("PageSize", PageSize);
            DataTable tb = dt.DATable(sql, paramPageIndex, paramPageSize);
            this.dt.CloseConnection();
            return tb;
        }
        public int RecordCountImages() //COUNT ROW IN TABLE IMAGES
        {
            int RC = 0;

            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from Images";
            RC = dt.GetValues(sql);
            this.dt.CloseConnection();
            return RC;
        }
        public Boolean NewImages(string ImagesName, string ImagesUrl, int UserUpload)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "Exec NewImages @ImagesName,@ImagesUrl,@UserUpload";
            SqlParameter pImagesName = (ImagesName == "") ? new SqlParameter("@ImagesName", DBNull.Value) : new SqlParameter("@ImagesName", ImagesName);
            SqlParameter pImagesUrl = (ImagesUrl == "") ? new SqlParameter("@ImagesUrl", DBNull.Value) : new SqlParameter("@ImagesUrl", ImagesUrl);
            SqlParameter pUserUpload = (UserUpload == 0) ? new SqlParameter("@UserUpload", DBNull.Value) : new SqlParameter("@UserUpload", UserUpload);
            this.dt.Updatedata(sqlquery, pImagesName, pImagesUrl, pUserUpload);
            this.dt.CloseConnection();
            return true;
        }
        //DELETE IMAGES
        public Boolean DeleteImages(string ImagesName)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "delete from Images where ImagesName=@ImagesName";
            SqlParameter pImagesName = new SqlParameter("@ImagesName", ImagesName);
            this.dt.Updatedata(sql, pImagesName);
            this.dt.CloseConnection();
            return true;
        }
        //ImagesID
        public int ImagesID(string ImagesName)
        {
            int imid = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select ID from Images where ImagesName=@ImagesName";
            SqlParameter pImagesName = new SqlParameter("@ImagesName", ImagesName);
            DataTable tb = dt.DATable(sql, pImagesName);
            foreach (DataRow r in tb.Rows)
            {
                imid = (string.IsNullOrEmpty(r[0].ToString())) ? 0 : (int)r[0];
            }
            this.dt.CloseConnection();
            return imid;
        }
    }
}
