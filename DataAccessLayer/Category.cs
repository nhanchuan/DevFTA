using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Category
    {
        private int iD;
        private string nameVN;
        private string nameEN;
        private int parent;
        private int itemIndex;
        private string permalink;
        private string seoTitle;
        private int cateogryImage;
        private int createBy;
        private DateTime createDate;
        private DateTime modifyDate;
        private int modifyBy;
        private string metaTitle;
        private string metaKeywords;
        private string metaDescriptions;
        private Boolean categoryStatus;
        private Boolean showOnHome;
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

        public string NameVN
        {
            get
            {
                return nameVN;
            }

            set
            {
                nameVN = value;
            }
        }

        public string NameEN
        {
            get
            {
                return nameEN;
            }

            set
            {
                nameEN = value;
            }
        }

        public int Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }

        public int ItemIndex
        {
            get
            {
                return itemIndex;
            }

            set
            {
                itemIndex = value;
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

        public string SeoTitle
        {
            get
            {
                return seoTitle;
            }

            set
            {
                seoTitle = value;
            }
        }

        public int CateogryImage
        {
            get
            {
                return cateogryImage;
            }

            set
            {
                cateogryImage = value;
            }
        }

        public int CreateBy
        {
            get
            {
                return createBy;
            }

            set
            {
                createBy = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return createDate;
            }

            set
            {
                createDate = value;
            }
        }

        public DateTime ModifyDate
        {
            get
            {
                return modifyDate;
            }

            set
            {
                modifyDate = value;
            }
        }

        public int ModifyBy
        {
            get
            {
                return modifyBy;
            }

            set
            {
                modifyBy = value;
            }
        }

        public string MetaTitle
        {
            get
            {
                return metaTitle;
            }

            set
            {
                metaTitle = value;
            }
        }

        public string MetaKeywords
        {
            get
            {
                return metaKeywords;
            }

            set
            {
                metaKeywords = value;
            }
        }

        public string MetaDescriptions
        {
            get
            {
                return metaDescriptions;
            }

            set
            {
                metaDescriptions = value;
            }
        }

        public bool CategoryStatus
        {
            get
            {
                return categoryStatus;
            }

            set
            {
                categoryStatus = value;
            }
        }

        public bool ShowOnHome
        {
            get
            {
                return showOnHome;
            }

            set
            {
                showOnHome = value;
            }
        }
    }
}
