using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    #region Default convetion
    // Her iki entity de Navigation property ile birebirlerini tekil olarak referans
    // ederek fiziksel bir ilişkinin olacağını ifade eder.

    //One to One ilişki türünde, dependent entity'nin hangisi olduğunu default olarak
    //belirleyebilmek pek kolay değildir. Bu durumda fiziksel olarak bir foreign keye
    //karşılık propert/kolon tanımlayarak çözüm getirebiliyoruz.

    //Böylece foreign key' e karşılık property tanımlayarak lüzümsuz bir kolon oluşturmuş oluyoruz.
    /*
    class Calisan
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public CalisanAdres CalisanAdres { get; set; } // Navigation property tanımladık
    }

    class CalisanAdres
    {
        public int Id { get; set; }
        public int CalisanId { get; set; } //Foreign Key property tanımladık
        public string Adres { get; set; }
        public Calisan Calisan { get; set; } // Navigation property tanımladık
    }
    */
    #endregion

    #region Data Annotations
    //Default Convetiona göre daha kullanışlı

    //Navigation Property'ler tanımlanmalıdır.

    //Foreign kolonunum ismi default convention dışında bir kolon olacaksa eğer ForeignKey
    //attribute ile bunu bildirebiliriz

    //Foreign Key kolonu oluşturulmak zorunda değildir.

    //1' e 1 ilişkide ekstradan foreign key kolonuna ihtiyaç olmayacağından dolayı dependent
    //entity'deki Id kolonunu hem foreign key hem de primary key olarak kullanmayı tercih
    //ediyoruz ve bu duruma özen gösterilir diyoruz.

    /*
    class Calisan
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public CalisanAdres CalisanAdres { get; set; } // Navigation property tanımladık
    }

    class CalisanAdres
    {
        [Key,ForeignKey(nameof(Calisan))]
        public int Id { get; set; }
        public string Adres { get; set; }
        public Calisan Calisan { get; set; } // Navigation property tanımladık
    }
    */
    #endregion

    #region Fluent API
    class Calisan
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public CalisanAdres CalisanAdres { get; set; } // Navigation property tanımladık
    }

    class CalisanAdres
    {
        [Key, ForeignKey(nameof(Calisan))]
        public int Id { get; set; }
        public string Adres { get; set; }
        public Calisan Calisan { get; set; } // Navigation property tanımladık
    }
    #endregion

    class ESirketDbContext : DbContext
    {

        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<CalisanAdres> CalisanAdresleri { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Provider
            //ConnectionString
            //Lazy Loading
            //vb. amaçlar için kullanır.

            optionsBuilder.UseSqlServer("Server= localhost,1433;Database=ECommerceDb;User Id sa;Passoword =1q2w3e4r+!");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calisan>()
                        .HasKey(c => c.CalisanAdres)
                        .WithOne(c => c.Calisan)
                        .HasForeignKey<CalisanAdres>(c => c.Id);
        }
    } 
}