using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lesson11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
        }
        static async void Islemler()
        {

            #region Veri Nasıl Güncellenir ?
            /*
        EticaterContext context=new();
            Urun urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
            urun.UrunAdi = "H Ürünü";
            urun.Fiyat = 999;
            await context.SaveChangesAsync();
            */
            #endregion
            #region ChangeTacker Nedir? Kısaca!
            // ChangeTacker, context üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır. Bu takip mekanizması sayesinde context 
            //üzerinden gelen verilerle ilgili işlemler neticesinden update yahut delete sorgularının oluşturulacağı anlaşılır!

            #endregion
            #region Takip Edilmeyen Nesneler Nasıl Güncellenir?
            /*
            EticaterContext context = new ();
            Urun urun = new(){Id = 3,UrunAdi = "Yeni ürün",Fiyat =123};
            */
            #region Update Fonksiyonu
            /*
            // ChangeTacker mekanizması tarafından takip edilmeyen nesnelerin güncellenebilmesi için Update fonksiyonu kullanılır!
            //Update fonksiyonu kullanabilmek için kesinlikle ilgili Id değeri verilmelidir. Bu değer güncellenecek(Update sorgusu oluşturulacak)
            //verinin hangisi olduğunu ifade edecektir.
             context.Urunler.Update(urun);
            await context.SaveChangesAsync();
            */
            #endregion
            #endregion
            #region EntityState Nedir?
            /*
            //Bir Entitt instance'nın durumunu ifade eden bir referanstır.
            EticaterContext context = new();
            Urun u = new();
            Console.WriteLine(context.Entry(u).State);
            */
            #endregion
            #region EF Core Açısından Bir Verinin Güncellenmesi Gerektiğini Nasıl Anlaşılıyor?
            /*
            EticaterContext context = new ();
            Urun urun =await context.Urunler.FirstOrDefaultAsync(u=> u.Id==3);
            Console.WriteLine(context.Entry(urun).State);
            urun.UrunAdi = "Helva";
            Console.WriteLine(context.Entry(urun).State);
            await context.SaveChangesAsync();
            Console.WriteLine(context.Entry(urun).State);
            */
            #endregion
            #region Birden Fazla Veri Güncellenirken Nelere Dikkat Edilmelidir?
            EticaterContext context = new ();

            var urunler = await context.Urunler.ToListAsync();
            foreach (var urun in urunler)
            {
                urun.UrunAdi += '*'; 
            }
            await context.SaveChangesAsync();
            #endregion
        }



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