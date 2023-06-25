using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml;

namespace Lesson12
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        static async void Islemler()
        {
            EticaterContext context = new();
            #region Veri Nasıl Silinir?
            /*
            Urun urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 5); // 5 Id sahip urunu tutar.
            context.Urunler.Remove(urun);
            await context.SaveChangesAsync();
            */
            #endregion
            #region Sİlme İşleminde ChangeTracker'ınr Rolü
            // ChangeTacker, context üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır. Bu takip mekanizması sayesinde context 
            //üzerinden gelen verilerle ilgili işlemler neticesinden update yahut delete sorgularının oluşturulacağı anlaşılır!
            #endregion
            #region Takip Edilmeyen Nesneler Nasıl Silinir?

            //Urun u = new(){Id = 2};
            //context.Urunler.Remove(u);
            //await context.SaveChangesAsync();

            #region EntityState İle Silme İşlemi
            //Urun u = new() { Id =1};
            //context.Entry(u).State = EntityState.Deleted;
            //await context.SaveChangesAsync();
            #endregion
            #endregion
            #region Birden Fazla Veri Kullanılırken Nelere Dikkat edilmelidir?
            #region SaveChanges'ı Verimli Kullanımı
            #endregion
            #region RemoveRange
           List<Urun> urunler =  await context.Urunler.Where(u => u.Id >=7 && u.Id <= 9).ToListAsync(); // 7 den büyük ve 9 dan küçük olan Id getir.
            context.Urunler.RemoveRange(urunler);
            await context.SaveChangesAsync();
            #endregion
            #endregion



        }
        public class EticaterContext : DbContext
        {
            public DbSet<Urun> Urunler { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // Provider
                //ConnectionString
                //Lazy Loading
                //vb. amaçlar için kullanır.

                optionsBuilder.UseSqlServer("Server= localhost,1433;Database=ECommerceDb;User Id sa;Passoword =1q2w3e4r+!");
            }
        }


        public class Urun
        {
            public int Id { get; set; }
            public string UrunAdi { get; set; }
            public float Fiyat { get; set; }
        }
    }
}