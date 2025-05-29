using OrangeHRM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Model
{
    internal class UserProfile
    {
        public string username { get; set; } = "Admin";
        public string password { get; set; } = "admin123";
        public string Firstname {  get; set; }= DataGenerator.GenerateRandomString();
        public string Lastname { get; set; } = DataGenerator.GenerateRandomString();
        public string Middlename{ get; set; }= DataGenerator.GenerateRandomString() ;
    }
}
