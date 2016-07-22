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
    public class SubSliderBLL
    {
        DataServices dt = new DataServices();
        public List<SubSlider> ListWithID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "select * from SubSlider where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DATable(sqlquery, pID);
            List<SubSlider> lst = new List<SubSlider>();
            foreach (DataRow r in tb.Rows)
            {
                SubSlider sb = new SubSlider();
                sb.ID = (int)r["ID"];
                sb.Title = (string.IsNullOrEmpty(r["Title"].ToString())) ? "" : (string)r["Title"];
                sb.Descriptions = (string.IsNullOrEmpty(r["Descriptions"].ToString())) ? "" : (string)r["Descriptions"];
                sb.SliderImg = (string.IsNullOrEmpty(r["SliderImg"].ToString())) ? 0 : (int)r["SliderImg"];
                sb.SliderStatus = (string.IsNullOrEmpty(r["SliderStatus"].ToString())) ? false : (Boolean)r["SliderStatus"];
                sb.SortOrder = (string.IsNullOrEmpty(r["SortOrder"].ToString())) ? 0 : (int)r["SortOrder"];
                sb.CreateBy = (string.IsNullOrEmpty(r["CreateBy"].ToString())) ? 0 : (int)r["CreateBy"];
                sb.CreateDate = (DateTime)r["CreateDate"];
                sb.RedirectLink = (string.IsNullOrEmpty(r["RedirectLink"].ToString())) ? "" : (string)r["RedirectLink"];
                lst.Add(sb);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<SubSlider> ListWithSortOrder(int SortOrder)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "select * from SubSlider where SortOrder=@SortOrder";
            SqlParameter pSortOrder = new SqlParameter("@SortOrder", SortOrder);
            DataTable tb = dt.DATable(sqlquery, pSortOrder);
            List<SubSlider> lst = new List<SubSlider>();
            foreach (DataRow r in tb.Rows)
            {
                SubSlider sb = new SubSlider();
                sb.ID = (int)r["ID"];
                sb.Title = (string.IsNullOrEmpty(r["Title"].ToString())) ? "" : (string)r["Title"];
                sb.Descriptions = (string.IsNullOrEmpty(r["Descriptions"].ToString())) ? "" : (string)r["Descriptions"];
                sb.SliderImg = (string.IsNullOrEmpty(r["SliderImg"].ToString())) ? 0 : (int)r["SliderImg"];
                sb.SliderStatus = (string.IsNullOrEmpty(r["SliderStatus"].ToString())) ? false : (Boolean)r["SliderStatus"];
                sb.SortOrder = (string.IsNullOrEmpty(r["SortOrder"].ToString())) ? 0 : (int)r["SortOrder"];
                sb.CreateBy = (string.IsNullOrEmpty(r["CreateBy"].ToString())) ? 0 : (int)r["CreateBy"];
                sb.CreateDate = (DateTime)r["CreateDate"];
                sb.RedirectLink = (string.IsNullOrEmpty(r["RedirectLink"].ToString())) ? "" : (string)r["RedirectLink"];
                lst.Add(sb);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public Boolean NewSubSlider(string Title, string Descriptions, int SliderImg, Boolean SliderStatus, int SortOrder, int CreateBy, string RedirectLink)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "Exec NewSubSlider @Title,@Descriptions,@SliderImg,@SliderStatus,@SortOrder,@CreateBy,@RedirectLink";
            SqlParameter pTitle = (Title == "") ? new SqlParameter("@Title", DBNull.Value) : new SqlParameter("@Title", Title);
            SqlParameter pDescriptions = (Descriptions == "") ? new SqlParameter("@Descriptions", DBNull.Value) : new SqlParameter("@Descriptions", Descriptions);
            SqlParameter pSliderImg = (SliderImg == 0) ? new SqlParameter("@SliderImg", DBNull.Value) : new SqlParameter("@SliderImg", SliderImg);
            SqlParameter pSliderStatus = new SqlParameter("@SliderStatus", SliderStatus);
            SqlParameter pSortOrder = new SqlParameter("@SortOrder", SortOrder);
            SqlParameter pCreateBy = new SqlParameter("@CreateBy", CreateBy);
            SqlParameter pRedirectLink = (RedirectLink == "") ? new SqlParameter("@RedirectLink", DBNull.Value) : new SqlParameter("@RedirectLink", RedirectLink);
            this.dt.Updatedata(sqlquery, pTitle, pDescriptions, pSliderImg, pSliderStatus, pSortOrder, pCreateBy, pRedirectLink);
            this.dt.CloseConnection();
            return true;
        }
        public int MaxItemindex()
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(SortOrder) from SubSlider";
            RC = dt.GetValues(sql);
            this.dt.CloseConnection();
            return RC;
        }
        public DataTable GetSubSliderPageWise(int PageIndex, int PageSize)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "Exec GetSubSliderPageWise @PageIndex,@PageSize";
            SqlParameter paramPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("PageSize", PageSize);
            DataTable tb = dt.DATable(sql, paramPageIndex, paramPageSize);
            this.dt.CloseConnection();
            return tb;
        }
        public int RecordCountSubSlider() //COUNT ROW PPopup
        {
            int RC = 0;

            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from SubSlider";
            RC = dt.GetValues(sql);
            this.dt.CloseConnection();
            return RC;
        }
        //Update Sort Order
        public Boolean UpdateSortOrder(int SortOrder, int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update SubSlider set SortOrder=@SortOrder where ID=@ID";
            SqlParameter pSortOrder = new SqlParameter("@SortOrder", SortOrder);
            SqlParameter pID = new SqlParameter("@ID", ID);
            this.dt.Updatedata(sql, pSortOrder, pID);
            this.dt.CloseConnection();
            return true;
        }
        //
        public int MaxItemindexLK(int SortOrder)
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(SortOrder) from SubSlider where SortOrder<@SortOrder";
            SqlParameter pSortOrder = new SqlParameter("@SortOrder", SortOrder);
            RC = dt.GetValues(sql, pSortOrder);
            this.dt.CloseConnection();
            return RC;
        }
        public int MinItemindexLK(int SortOrder)
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(SortOrder) from SubSlider where SortOrder>@SortOrder";
            SqlParameter pSortOrder = new SqlParameter("@SortOrder", SortOrder);
            RC = dt.GetValues(sql, pSortOrder);
            this.dt.CloseConnection();
            return RC;
        }
        //Update status
        public Boolean UpdateStatus(int ID, Boolean status)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update SubSlider set SliderStatus=@SliderStatus where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pstatus = new SqlParameter("@SliderStatus", status);
            this.dt.Updatedata(sql, pID, pstatus);
            this.dt.CloseConnection();
            return true;
        }
        //Show
        public DataTable ShowSubSlider()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "Exec ShowSubSlider";
            DataTable tb = dt.DATable(sql);
            this.dt.CloseConnection();
            return tb;
        }
        //Update
        public Boolean UpdateSubSlider(int ID, string Title, string Descriptions, int SliderImg, Boolean SliderStatus, string RedirectLink)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "Exec UpdateSubSlider @ID,@Title,@Descriptions,@SliderImg,@SliderStatus,@RedirectLink";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pTitle = (Title == "") ? new SqlParameter("@Title", DBNull.Value) : new SqlParameter("@Title", Title);
            SqlParameter pDescriptions = (Descriptions == "") ? new SqlParameter("@Descriptions", DBNull.Value) : new SqlParameter("@Descriptions", Descriptions);
            SqlParameter pSliderImg = (SliderImg == 0) ? new SqlParameter("@SliderImg", DBNull.Value) : new SqlParameter("@SliderImg", SliderImg);
            SqlParameter pSliderStatus = new SqlParameter("@SliderStatus", SliderStatus);
            SqlParameter pRedirectLink = (RedirectLink == "") ? new SqlParameter("@RedirectLink", DBNull.Value) : new SqlParameter("@RedirectLink", RedirectLink);
            this.dt.Updatedata(sql, pID, pTitle, pDescriptions, pSliderImg, pSliderStatus, pRedirectLink);
            this.dt.CloseConnection();
            return true;
        }
        //Update Images
        public Boolean UpdateImage(int ID, int SliderImg)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update SubSlider set SliderImg=@SliderImg where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pSliderImg = new SqlParameter("@SliderImg", SliderImg);
            this.dt.Updatedata(sql, pID, pSliderImg);
            this.dt.CloseConnection();
            return true;
        }
        //Delete
        public Boolean DeleteWithID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "delete from SubSlider where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            this.dt.Updatedata(sql, pID);
            this.dt.CloseConnection();
            return true;
        }
    }
}
