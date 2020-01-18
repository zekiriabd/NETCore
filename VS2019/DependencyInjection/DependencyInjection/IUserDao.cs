using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IUserDao
    {
        public string[] getDbUser();
    }
}
