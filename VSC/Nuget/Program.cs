using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Nuget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<User> users = new List<User>();
            users.Add(new User("zekiri1","Abdelali1"));
            users.Add(new User("zekiri2","Abdelali2"));
            users.Add(new User("zekiri3","Abdelali3"));

            var MyJson = JsonConvert.SerializeObject(users);
            Console.WriteLine(MyJson);
        }
    }

    public class User{
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public User(string fname,string lname){
               this.FirstName = fname; 
               this.LastName  = lname; 
        }
    }


}
