using System;
using System.Collections.Generic;
using System.Text;

namespace MVCDependencyInjection
{
    public class UserService : IUserService
    {
        public IUserDao oUserDao { get; set; }

        public string getFullName()
        {
            string[] userinfo = oUserDao.getDbUser();
            return userinfo[0] + " _ " + userinfo[1];
        }

        public UserService(IUserDao userDao)
        {
            this.oUserDao = userDao;
        }
    }
}
