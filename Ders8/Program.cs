using Microsoft.EntityFrameworkCore;
namespace Lesson8
{
    public class Program
    {
        static  void Main(string[] args)
        {
            Console.Write("hello");
        }
    }
    public class EcommerceDbContext : DbContext // Microsoft.EntityFrameworkCore kütüphanesini yükleyin
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //projeye uygun Provider yükleyin ben sqlServer kütüphanesini kullandım
            optionsBuilder.UseSqlServer("Server= localhost,1433;Database=ECommerceDb;User Id sa;Passoword =1q2w3e4r+!");
        }
    }

    //Entity
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public int Quantity { get; set; }
        public float Price { get; set; }
    }

    //Entity
    public class Customer
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }    
    }
}