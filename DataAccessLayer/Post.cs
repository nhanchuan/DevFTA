using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Post
    {
        private int iD;
        private string titleVN;
        private string titleEN;
        private string postContentVN;
        private string postContentEN;
        private int createBy;
        private DateTime createDate;
        private DateTime modifyDate;
        private int modifyBy;
        private string metaTitle;
        private string metaKeywords;
        private string metaDescriptions;
        public bool PostStatus;
        private int viewCount;
        public bool TopHot;
        private int postImages;

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

        public string TitleVN
        {
            get
            {
                return titleVN;
            }

            set
            {
                titleVN = value;
            }
        }

        public string TitleEN
        {
            get
            {
                return titleEN;
            }

            set
            {
                titleEN = value;
            }
        }

        public string PostContentVN
        {
            get
            {
                return postContentVN;
            }

            set
            {
                postContentVN = value;
            }
        }

        public string PostContentEN
        {
            get
            {
                return postContentEN;
            }

            set
            {
                postContentEN = value;
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

        public int ViewCount
        {
            get
            {
                return viewCount;
            }

            set
            {
                viewCount = value;
            }
        }

        public int PostImages
        {
            get
            {
                return postImages;
            }

            set
            {
                postImages = value;
            }
        }
    }
}
