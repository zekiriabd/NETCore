using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type tUserDao     = Type.GetType("DependencyInjection.UserDao");
            Type tUserService = Type.GetType("DependencyInjection.UserService");
            
            IUserDao oUserDao = (IUserDao) Activator.CreateInstance(tUserDao);
            IUserService oUserService = (IUserService) Activator.CreateInstance(tUserService, oUserDao);

            string name = oUserService.getFullName();
            Console.WriteLine("###############################");
            Console.WriteLine(name);
            Console.WriteLine("###############################");

        }
    }
}
