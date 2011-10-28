using System;
using System.Linq;
using System.Web;
using Chat.Core.Impl;
using Chat.DataAccess.Data;
using Chat.DataAccess.Interfaces;

namespace Chat.BusinessLogic.Data
{
    public static class Authorization
    {
        public static void CheckRoles (string first)
        {
            if (string.IsNullOrEmpty(first))
            {
                throw new ArgumentNullException();
            }

            if (HttpContext.Current != null)
            {
                var request = HttpContext.Current.Request;
                var cookie = request.Cookies.Get("userId");
               
                if (cookie != null)
                {
                    string userId = cookie.Value;

                    IRepository<User_Role> userRoleRepository = ContainerService.Instance.Resolve<IRepository<User_Role>>();
                    var roles = userRoleRepository.FindAll(u => u.UserId == Convert.ToInt16(userId));

                    var rolExist = roles.FirstOrDefault(r => r.Role.Name == first);

                    if (rolExist == null && first != "ChatCreator")
                        throw new Exception("Unauthorized");
                }
            }
        }
    }
}
