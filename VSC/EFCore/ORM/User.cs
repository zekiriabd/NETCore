using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class User
{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
}


 public class UserDBContext : DbContext {

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MAGJ7HQ\SQLEXPRESS;Initial Catalog=USER_Managment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
            .ToTable("USERDB")
            .HasKey(x=>x.Id);
    }
 }

 public static class UserManager
{
    public static List<User> UserList()
    {
        using (var db = new UserDBContext())
        {
            return db.Users.OrderBy(p => p.FirstName).ToList();
        }
    }

    public static User UserById(int id)
    {
        using (var db = new UserDBContext())
        {
            return db.Users.Find(id);
        }
    }

    public static void DelUserById(int id)
    {
        using (var db = new UserDBContext())
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }

    public static void UpdateUser(User newUser)
    {
        using (var db = new UserDBContext())
        {
            db.Users.Update(newUser);
            db.SaveChanges();
        }
    }



    public static void AddUser(User newUser)
    {
        using (var db = new UserDBContext())
        {
            db.Users.Add(newUser);
            db.SaveChanges();
        }
    }
}
