using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectFriend_
{
    internal class User
    {
        public static List<User> users = new List<User>();

        public int ID;
        public string Name;
        public string Surname;
        public string Email;
        public string SchoolName;
        public string Password;
    }
}
