using ApartmentManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManager.Access.DB
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=ApartmentDB;integrated security=true;");
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Message> Messages { get; set; }
        
    }
}
