using System.Collections.Generic;
using Chat.DataAccess.Data;

namespace Chat.BusinessLogic.Data.Model
{
    public class UserInfo:Entity
    {
        public string Name { set; get; }
        public string Password { set; get; }
        public List<Role> UserRole { set; get; }
    }
}