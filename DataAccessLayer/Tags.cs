using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Tags
    {
        private int iD;
        private string tagsName;
        private string descritption;
        private string permalink;
        private DateTime dateOfCreate;
        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public string TagsName
        {
            get
            {
                return tagsName;
            }

            set
            {
                tagsName = value;
            }
        }

        public string Descritption
        {
            get
            {
                return descritption;
            }

            set
            {
                descritption = value;
            }
        }

        public string Permalink
        {
            get
            {
                return permalink;
            }

            set
            {
                permalink = value;
            }
        }

        public DateTime DateOfCreate
        {
            get
            {
                return dateOfCreate;
            }

            set
            {
                dateOfCreate = value;
            }
        }
    }
}
