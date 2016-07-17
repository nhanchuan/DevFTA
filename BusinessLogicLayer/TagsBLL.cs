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
    public class TagsBLL
    {
        DataServices dt = new DataServices();
        public List<Tags> ListAllTags()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquerry = "select * from Tags";
            DataTable tb = dt.DATable(sqlquerry);
            List<Tags> lst = new List<Tags>();
            foreach (DataRow r in tb.Rows)
            {
                Tags tg = new Tags();
                tg.ID = (int)r["ID"];
                tg.TagsName = (string.IsNullOrEmpty(r["TagsName"].ToString())) ? "" : (string)r["TagsName"];
                tg.Descritption = (string.IsNullOrEmpty(r["Descritption"].ToString())) ? "" : (string)r["Descritption"];
                tg.Permalink = (string.IsNullOrEmpty(r["Permalink"].ToString())) ? "" : (string)r["Permalink"];
                tg.DateOfCreate = (DateTime)r["DateOfCreate"];
                lst.Add(tg);
            }
            this.dt.CloseConnection();
            return lst;
        }
        //New
        public Boolean NewTags(string TagsName, string Descritption, string Permalink)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "insert into Tags(TagsName,Descritption,Permalink) values (@TagsName,@Descritption,@Permalink)";
            SqlParameter pTagsName = (TagsName == "") ? new SqlParameter("@TagsName", DBNull.Value) : new SqlParameter("@TagsName", TagsName);
            SqlParameter pDescritption = (Descritption == "") ? new SqlParameter("@Descritption", DBNull.Value) : new SqlParameter("@Descritption", Descritption);
            SqlParameter pPermalink = (Permalink == "") ? new SqlParameter("@Permalink", DBNull.Value) : new SqlParameter("@Permalink", Permalink);
            this.dt.Updatedata(sqlquery, pTagsName, pDescritption, pPermalink);
            this.dt.CloseConnection();
            return true;
        }
        //Check Exist
        public List<Tags> getTagsWithName(string name)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sqlquery = "select * from Tags where TagsName=@name";
            SqlParameter ptagname = new SqlParameter("name", name);
            DataTable tb = dt.DATable(sqlquery, ptagname);
            List<Tags> lst = new List<Tags>();
            foreach (DataRow r in tb.Rows)
            {
                Tags t = new Tags();
                t.ID = (int)r[0];
                t.TagsName = (string.IsNullOrEmpty(r["TagsName"].ToString())) ? "" : (string)r["TagsName"];
                t.Descritption = (string.IsNullOrEmpty(r["Descritption"].ToString())) ? "" : (string)r["Descritption"];
                t.Permalink = (string.IsNullOrEmpty(r["Permalink"].ToString())) ? "" : (string)r["Permalink"];
                t.DateOfCreate = (DateTime)r["DateOfCreate"];
                lst.Add(t);
            }
            this.dt.CloseConnection();
            return lst;
        }

        //New Tags With TagName
        public Boolean newTagsName(string tagsname)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sqlquery = "insert into Tags(TagsName) values(@tagsname)";
            SqlParameter ptagsname = new SqlParameter("tagsname", tagsname);
            this.dt.Updatedata(sqlquery, ptagsname);
            this.dt.CloseConnection();
            return true;
        }
    }
}
