using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class UsersModelEdit
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupID { get; set; }

        public UsersModelEdit(int userID, string password, string username, string firstName, string lastName, int groupID)
        {
            UserID = userID;
            Password = password;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            GroupID = groupID;
        }

        public UsersModelEdit(string password, string username, string firstName, string lastName, int groupID)
        {
            Password = password;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            GroupID = groupID;
        }

        public UsersModelEdit()
        {

        }
    }
}
