using System;
using System.Collections.Generic;
using System.Text;

namespace MVCDependencyInjection
{
    public class UserDao : IUserDao
    {
        public string[] getDbUser()
        {
            /*الاتصال بالقاعدة و جلب البيانات*/
            string[] result = { "Zekiri", "Abdelali" };
            return result;
        }

        public UserDao()
        {
            Console.WriteLine("is created");
        }
    }
}
