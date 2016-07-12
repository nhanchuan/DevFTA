using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserAdminProfile
    {
        private int profileID;
        private int adminID;
        private string firstName;
        private string lastName;
        public bool Sex;
        private DateTime birthday;
        private string userAddress;
        private int images;
        public bool ProfileStatus;
        private DateTime dateOfStart;
        public int ProfileID
        {
            get
            {
                return profileID;
            }

            set
            {
                profileID = value;
            }
        }

        public int AdminID
        {
            get
            {
                return adminID;
            }

            set
            {
                adminID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
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

        public int Images
        {
            get
            {
                return images;
            }

            set
            {
                images = value;
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
