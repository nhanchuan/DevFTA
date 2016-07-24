using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SubMenuItem
    {
        private int iD;
        private int menuID;
        private int categoryID;
        private int sortOrder;
        private string ortherItem;
        private string permalink;
        private int postID;
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

        public int MenuID
        {
            get
            {
                return menuID;
            }

            set
            {
                menuID = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return categoryID;
            }

            set
            {
                categoryID = value;
            }
        }

        public int SortOrder
        {
            get
            {
                return sortOrder;
            }

            set
            {
                sortOrder = value;
            }
        }

        public string OrtherItem
        {
            get
            {
                return ortherItem;
            }

            set
            {
                ortherItem = value;
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

        public int PostID
        {
            get
            {
                return postID;
            }

            set
            {
                postID = value;
            }
        }
    }
}
