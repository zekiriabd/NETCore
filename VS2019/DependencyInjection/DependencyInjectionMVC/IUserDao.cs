﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionMVC
{
    public interface IUserDao
    {
        public string[] getDbUser();
    }
}
