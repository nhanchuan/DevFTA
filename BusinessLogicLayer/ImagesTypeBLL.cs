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
    public class ImagesTypeBLL
    {
        DataServices dt = new DataServices();
        public DataTable ListAllItem()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlqurey = "select ID,Name,[dbo].[CountImgesOfCT](ID) as NumImages from ImagesType";
            DataTable tb = dt.DATable(sqlqurey);

            this.dt.CloseConnection();
            return tb;
        }
        public List<ImagesType> ListWithID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlqurey = "select * from ImagesType where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DATable(sqlqurey, pID);
            List<ImagesType> lst = new List<ImagesType>();
            foreach (DataRow r in tb.Rows)
            {
                ImagesType it = new ImagesType();
                it.ID = (int)r["ID"];
                it.Name = (string.IsNullOrEmpty(r["Name"].ToString())) ? "" : (string)r["Name"];
                lst.Add(it);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<ImagesType> ListWithName(string Name)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlqurey = "select * from ImagesType where Name=@Name";
            SqlParameter pName = new SqlParameter("@Name", Name);
            DataTable tb = dt.DATable(sqlqurey, pName);
            List<ImagesType> lst = new List<ImagesType>();
            foreach (DataRow r in tb.Rows)
            {
                ImagesType it = new ImagesType();
                it.ID = (int)r["ID"];
                it.Name = (string.IsNullOrEmpty(r["Name"].ToString())) ? "" : (string)r["Name"];
                lst.Add(it);
            }
            this.dt.CloseConnection();
            return lst;
        }

        /// <summary>
        /// Create New Images Category
        /// </summary>
        /// <param name="Name"> Category Name</param>
        /// <returns></returns>
        public Boolean NewImagesType(string Name)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "insert into ImagesType(Name) values(@Name)";
            SqlParameter pName = new SqlParameter("@Name", Name);
            this.dt.Updatedata(sqlquery, pName);
            this.dt.CloseConnection();
            return true;
        }
        //Delete
        public Boolean DeleteImagesType(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "delete from ImagesType where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            this.dt.Updatedata(sqlquery, pID);
            this.dt.CloseConnection();
            return true;
        }
        //Update
        public Boolean UpdateImagesType(int ID, string Name)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "update ImagesType set Name=@Name where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pName = (Name == "") ? new SqlParameter("@Name", DBNull.Value) : new SqlParameter("@Name", Name);
            this.dt.Updatedata(sqlquery, pName, pID);
            this.dt.CloseConnection();
            return true;
        }

    }
}
