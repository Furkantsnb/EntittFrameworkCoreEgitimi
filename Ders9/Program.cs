
using Microsoft.EntityFrameworkCore;

namespace Lesson9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class ETicaretDbContext : DbContext
    {
        public DbSet<Urun> Urunler {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Provider
            //ConnectionString
            //Lazy Loading
            //vb. amaçlar için kullanır.

            optionsBuilder.UseSqlServer("Server= localhost,1433;Database=ECommerceDb;User Id sa;Passoword =1q2w3e4r+!"); 
        }

    }

    //Entity
    public class Urun
    {
        public int Id { get; set; }

        //public int Id { get; set; }
        //public int ID { get; set; }
        //public int UrunId { get; set; }
        //public int UrunID { get; set; }
        //Şeklinde tanımlandığında EF Core bunları hususi olarak primary key olarak belirleyecektir.

    }

    #region OnConfiguring İle Konfigürasyon Ayarlarını Gerçekleştirmek
    //Ef Core tool' un yapılandırmak için kullandığımız bir metottdur.
    //Contect nesnesinde override edilerek kullanılmaktadır.
    #endregion

    #region Basit Düzeyde Entity Tanımlama Kuralları
    //EF Core, her tablonun default olarak bir primary key kolonu olması gerektiğini kabul eder!
    //Haliyle, bu kolonun temsil eden bir property tanımlamadığımız taktirde hata verecektir!
    #endregion

   
}