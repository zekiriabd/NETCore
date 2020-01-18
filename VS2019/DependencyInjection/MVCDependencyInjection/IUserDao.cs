using System;
using System.Collections.Generic;
using System.Text;

namespace MVCDependencyInjection
{
    public interface IUserDao
    {
        string[] getDbUser();
    }
}
