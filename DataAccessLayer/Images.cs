using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Images
    {
        private int iD;
        private string imagesName;
        private string imagesUrl;
        private int imagesType;
        private int userUpload;
        private DateTime dateOfStart;
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

        public string ImagesName
        {
            get
            {
                return imagesName;
            }

            set
            {
                imagesName = value;
            }
        }

        public string ImagesUrl
        {
            get
            {
                return imagesUrl;
            }

            set
            {
                imagesUrl = value;
            }
        }

        public int ImagesType
        {
            get
            {
                return imagesType;
            }

            set
            {
                imagesType = value;
            }
        }

        public int UserUpload
        {
            get
            {
                return userUpload;
            }

            set
            {
                userUpload = value;
            }
        }

        public DateTime DateOfStart
        {
            get
            {
                return dateOfStart;
            }

            set
            {
                dateOfStart = value;
            }
        }
    }
}
