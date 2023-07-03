using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region Default Convetion
    //Default convetion yönteminde bire çok ilişkiyi kurarken foreign key kolonuna karşılık
    //gelen bir property tanımlamak mecburiyetinde değilizdr. Eğer tanımlamazsak EF Core bunu
    //kendisi tamamlayacak yok eğer tanımlarsak, tanımladığımızı baz alacaktır.

    /*
     
    class Calisan //Dependent Entity
    {
        public int Id { get; set; }
        public string Adi { get; set; }

        public Departman Departman { get; set; }
    }

    class Departman
    {
        public int Id { get; set; }
        public string DepartmanAdi { get; set; }

        public ICollection<Calisan> Calisanlar {  get; set; }
    }
    */

    #endregion

    #region Data Annotations
    //Default Convetion yönteminde forenign key kolonuna karşılık gelen property'i
    //tanımladığımızda bu property ismi temel geleneksel entity tanımlama kurallarına
    //uymuyorsa eğer Data Annotations lar ile müdahalede bulunabiliriz

    /*
    class Calisan //Dependent Entity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Departman))]
        public int DId { get; set; }//Foreign Key kolonu
        public string Adi { get; set; }

        public Departman Departman { get; set; }
    }

    class Departman
    {
        public int Id { get; set; }
        public string DepartmanAdi { get; set; }

        public ICollection<Calisan> Calisanlar { get; set; }

    */
    #endregion

    #region Fluent API  
    class Calisan //Dependent Entity
    {
        public int Id { get; set; }
        
       //public int DId { get; set; }
       //Foreign Key kolonunu eğer  Fluent API üzerinden tanımlamak istiyorsak OnModelCreating kısmına .HasForeignKey(c => c.DId); tanımlamamız gerekiyor.
        public string Adi { get; set; }

        public Departman Departman { get; set; }
    }

    class Departman
    {
        public int Id { get; set; }
        public string DepartmanAdi { get; set; }

        public ICollection<Calisan> Calisanlar { get; set; }
        #endregion

        class ESirketDbContext : DbContext
        {

            public DbSet<Calisan> Calisanlar { get; set; }
            public DbSet<Departman> CalisanAdresleri { get; set; }
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
                    .HasOne(c => c.Departman)
                    .WithMany(d => d.Calisanlar);
                    //.HasForeignKey(c => c.DId);
            }
        }
    }
}