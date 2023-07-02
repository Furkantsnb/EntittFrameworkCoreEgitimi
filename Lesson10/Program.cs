using Microsoft.EntityFrameworkCore;

namespace Lesson10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
        }
        static async Task main(string[] args)
        {
          

            #region Veri Nasıl Eklenir?
            /*
           
            EticaterContext context = new ();
            Urun urun = new()
            {
                UrunAdi = "A Ürünü",
                Fiyat = 1000
            }; 

           // context.AddAsync Fonksiyonu  object olarak veri eklememizi sağlıyor
           await context.AddAsync(urun);

           //Context.DbSet.AddAsync Fonksiyonu  tip güvenli veri eklememizi sağlıyor
           context.Urunler.AddAsync(urun);

            await context.SaveChangesAsync(); 
            // SaveChanges insert, update ve delete sorgularını oluşturup bir transaction eşliğinde veritabanına gönderip execute eden fonksiyondur.
            // Eğer ki oluşturulan sorgulardan herhangi biri başarısız olursa tüm işlemleri geri alır (rollback)
           */
            #endregion
            #region EF Core açısından bir verinin eklenmesi gerektiğini nasıl anlarız
            /*
            EticaterContext context = new();
            Urun urun = new Urun()
            {
                UrunAdi = "B Ürünü",
                Fiyat = 2000
            };
            Console.WriteLine(context.Entry(urun).State); //Detached

            await context.AddAsync(urun);
            Console.WriteLine(context.Entry(urun).State);//Added

            await context.SaveChangesAsync();
            Console.WriteLine(context.Entry(urun).State);//Unchanged
            */
            #endregion
            #region Birden fazka veri alırken nelere dikkat edilmelidir?


            /*SaveChanges fonksiyonu her tetiklendiğinde bir transaction oluşturacağından dolayı EF Core ile yapılan her bir işleme
             özel kullanmaktan kaçınmalıyız! Çünkü her işlem özel transaction veri tabanı açısından ekstradan maliyet demektir.
             O yüzden mümkün mertebe tüm işlemlerimizi tek bir transaction eşliğinde veri tabanına gönderebilmek için savechanges' ı aşağıdaki gibi 
            tek seferde kullanmak hem maliyet hem de yönetilebilirlik açısından katkıda bulunmuş olacaktır.
            */
            /*
            EticaterContext context = new();
            Urun urun = new Urun()
            {
                UrunAdi = "C Ürünü",
                Fiyat = 3000
            };
            Urun urun2 = new Urun()
            {
                UrunAdi = "D Ürünü",
                Fiyat = 3000
            };
            Urun urun3 = new Urun()
            {
                UrunAdi = "E Ürünü",
                Fiyat = 3000
            };
            await context.AddAsync(urun);
            await context.AddAsync(urun2);
            await context.AddAsync(urun3);
            await context.SaveChangesAsync();
            */

            #endregion
            #region AddRange Fonksiyonu kullanımı
            /*
            EticaterContext context = new();
            Urun urun = new Urun()
            {
                UrunAdi = "C Ürünü",
                Fiyat = 3000
            };
            Urun urun2 = new Urun()
            {
                UrunAdi = "C Ürünü",
                Fiyat = 3000
            };
            Urun urun3 = new Urun()
            {
                UrunAdi = "C Ürünü",
                Fiyat = 3000
            };
           await context.AddRangeAsync(urun,urun2,urun3);
            await context.SaveChangesAsync();
            */
            #endregion
            #region Eklenen Verinin Generate Edilen Id' sini Elde Etme

            EticaterContext context = new();
            Urun urun = new Urun()
            {
                UrunAdi = "G Ürünü",
                Fiyat = 3000
            };
            await context.AddAsync(urun);
            await context.SaveChangesAsync();
            Console.WriteLine(urun.Id); // Id numarasını çıktı olarak veriyor
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