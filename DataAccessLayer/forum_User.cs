using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class forum_User
    {
        private int userID;
        private string userName;
        private string passwords;
        private string phoneNumber;
        public bool Male;
        private string email;
        private DateTime birthdate;
        private string userAddress;
        public bool IsActive;
        private int userImages;
        private DateTime createDate;

        public int UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Passwords
        {
            get
            {
                return passwords;
            }

            set
            {
                passwords = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }

            set
            {
                birthdate = value;
            }
        }

        public string UserAddress
        {
            get
            {
                return userAddress;
            }

            set
            {
                userAddress = value;
            }
        }

        public int UserImages
        {
            get
            {
                return userImages;
            }

            set
            {
                userImages = value;
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
    }
}
