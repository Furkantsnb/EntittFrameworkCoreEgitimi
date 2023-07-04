using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace Lesson24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region Default Convention
    //İki Entity arasındaki ilişkiyi navigation propertyler üzerinden çoğul olarak kurmalıyız.(ICollection, List)

    //Default Convetion'da cross table'ı manuel oluşturmak zorunda değiliz. EF Core tasarıma uyhun bir şekilde
    //cross table'ı kendisi otomatik basacak ve generate edecektir.

    //Ve oluşturulan cross table'ın içerisinde composite primary key'i deotomatik oluşturmuş olacaktır. 
    /*
    class Kitap
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public ICollection<Yazar> Yazarlar { get; set; }    
    }

    class Yazar
    {
        public int Id { get; set; }
        public string YazarAdi { get; set; }
        public ICollection<Kitap> Kitaplar {  get; set; }
    }
    */
    #endregion

    #region Data Annotations
    //Cross table manuel olarak oluşturulmak zorundadır.

    //Entity2lerde oluşturduğumuz cross table entity si ile bire çok bir ilişki kurulmalı.

    //Crıss table primary Key'i data annotation(attributes)lar ile manuel kuramıyoruz. Bunun
    //için de fluent Apı'da çalışma yapmamız gerekiyor. 

    //Cross table'a karşılık bir entity modeli oluşturuyorsak eğer bunu context sınıfı içerisinde 
    //DbSet propert2si olarak bildirmek mecburiyetinde değiliz!

    //FereignKey kullanarak Foren key kolon ismin değiştirebilirsin
    /*
    class Kitap
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public ICollection<KitapYazar> Yazarlar { get; set; }
    }
    //Cross Table
    class KitapYazar
    {
        public int KitapId { get; set; }
        public int YazarId { get; set; }

        public Kitap Kitap { get; set; }
        public Yazar Yazar { get; set; }
    }

    class Yazar
    {
        public int Id { get; set; }
        public string YazarAdi { get; set; }
        public ICollection<KitapYazar> Kitaplar { get; set; }
    } 
    */
    #endregion

    #region Fluent API
    //Cross table manuel oluşturulmalı
    
    //DbSet olarak eklenmesine lüzüm yok

    //Composite Primary Key Haskey metodu ile kurulmalı!


    class Kitap
    {
       
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public ICollection<KitapYazar> Yazarlar { get; set; }
    }

    //Cross Table
    class KitapYazar
    {
        public int KitapId { get; set; }
        public int YazarId { get; set; }

        public Kitap Kitap { get; set; }
        public Yazar Yazar { get; set; }
    }

    class Yazar
    {
        public int Id { get; set; }
        public string YazarAdi { get; set; }
        public ICollection<KitapYazar> Kitaplar { get; set; }
    }
    #endregion


    class EKitapDbContext : DbContext
    {

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Provider
            //ConnectionString
            //Lazy Loading
            //vb. amaçlar için kullanır.

            optionsBuilder.UseSqlServer("Server= localhost,1433;Database=ECommerceDb;User Id sa;Passoword =1q2w3e4r+!");

        }

        // Data Annotations 
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<KitapYazar>()
        //         .HasKey(ky => new{ky.KitapId, ky.YazarId});
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KitapYazar>()
                        .HasKey(ky => new {ky.KitapId, ky.YazarId});

            modelBuilder.Entity<KitapYazar>()
                        .HasOne(k => k.Kitap)
                        .WithMany(k => k.Yazarlar)
                        .HasForeignKey(ky => ky.KitapId);   

            modelBuilder.Entity<KitapYazar>()
                        .HasOne(k => k.Yazar)
                        .WithMany(k => k.Kitaplar)
                        .HasForeignKey(ky => ky.YazarId);
        }
    }
}