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
        public Boolean NewImages(string ImagesName, string ImagesUrl, int ImagesType, int UserUpload)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "Exec NewImages @ImagesName,@ImagesUrl,@ImagesType,@UserUpload";
            SqlParameter pImagesName = (ImagesName == "") ? new SqlParameter("@ImagesName", DBNull.Value) : new SqlParameter("@ImagesName", ImagesName);
            SqlParameter pImagesUrl = (ImagesUrl == "") ? new SqlParameter("@ImagesUrl", DBNull.Value) : new SqlParameter("@ImagesUrl", ImagesUrl);
            SqlParameter pImagesType = (ImagesType == 0) ? new SqlParameter("@ImagesType", DBNull.Value) : new SqlParameter("@ImagesType", ImagesType);
            SqlParameter pUserUpload = (UserUpload == 0) ? new SqlParameter("@UserUpload", DBNull.Value) : new SqlParameter("@UserUpload", UserUpload);
            this.dt.Updatedata(sqlquery, pImagesName, pImagesUrl, pImagesType, pUserUpload);
            this.dt.CloseConnection();
            return true;
        }
    }
}
