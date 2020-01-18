using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDI
{
    public interface IUserDao
    {
        string[] getDbUser();
    }
}
