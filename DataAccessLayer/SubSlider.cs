using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SubSlider
    {
        private int iD;
        private string title;
        private string descriptions;
        private int sliderImg;
        public bool SliderStatus;
        private int sortOrder;
        private int createBy;
        private DateTime createDate;
        private string redirectLink;
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

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Descriptions
        {
            get
            {
                return descriptions;
            }

            set
            {
                descriptions = value;
            }
        }

        public int SliderImg
        {
            get
            {
                return sliderImg;
            }

            set
            {
                sliderImg = value;
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

        public string RedirectLink
        {
            get
            {
                return redirectLink;
            }

            set
            {
                redirectLink = value;
            }
        }
    }
}
