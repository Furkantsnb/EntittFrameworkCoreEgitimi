using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lesson20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        static async void Islemler()
        {
            ETicaterContext context = new();


            #region AsNoTracking Metodu
            //Context üzerinden gelen tüm datalar Change Tacker mekanizması tarafından takip edilmektedir.

            // Changes Tracker, takip ettiği nesnelerin sayısıyla doğru orantılı olacak şekilde bir 
            // maliyete sahiptir. O yüzden üzerinde işlem yapılmayacak verilerin takip edilmesi bizlere 
            //lüzumsuz yere bir maliyer ortaya çıkaracaktır.

            //AsNoTracking metodu, context üzerinden sorgu neticesinde gelecek olan verilerin Change
            //Tracker tarafından takip edilmesini engeller.

            //AsNoTracking fonksiyonu ile yapılan sorgulamalarda, verileri elde edebilir, bu verileri 
            //istenilen noktalarda kullanabilir lakin veriler üzerinde herhangi bir değişiklik/update
            // işlemleri yapamayız

            

            var kullanicilar = await context.Kullanicilar.AsNoTracking().ToListAsync(); //Changes Tracker mekanizması devre dışı kalır.

            foreach(var kullanici in kullanicilar)
            {
                Console.WriteLine(kullanici.KullaniciAdi);// verileri çekiyoruz bundan dolayı Changes Tacker mekanızması gerekmiyor.
                kullanici.KullaniciAdi = $"yeni-{kullanici.KullaniciAdi}"; // kullanıcı adı güncellediğimiz halde Changes Tracker mekanizması çalışmadığı için güncellenmiyor.
            }
            await context.SaveChangesAsync();
            #endregion

            #region AsNoTrackingWithIdentityResolution
            //Change Tracker mekanizması sayesinde yinelenen dayalar aynı instanceleri kullanırlar

            //!!! AsNoTacking metodu ile yapılan sorgularda yinelenen datalar farklı instacalarda karşılanırlar.

            //Change Tracker mekanizması yinelenen verileri tekil instance olarak getirir. Buradan
            //ekstra bir performans kazancı söz konusudur.

            //Bizler yaptığımız sorgularda takip mekanizmasını AsNoTrackin metodu ile maliyetini kırmak
            // isterken bazen maliyete sebebiyer verebiliriz. (Özlellikle ilişkisel tabloları sorgularken
            // bu duruma dikkat etmemiz gerekiyor.)

            //AsNoTacking ile elde edilen veriler takip edilmeyeceğinden dolayı yinelenen verilerin ayrı
            //istancelarda olması sebebiyet veriyoruz. Çünkü Change Tracker mekanizması takip ettiği nesneden
            //bellekte varsa eğer aynı nesneden bir daha oluşturma gereği duymaksızın o nesneye ayrı noktalardaki 
            //ihtiyaci aynı instance üzerinden gidermektedir.

            //Böyle bir durumda hem takip mekanizmasının maliyetini ortadan kaldırmak hemde yinelenen
            //dataları tek bir instance üzerinde karşılamak için AsNoTrackinWithIdentityResolution 
            //fonksiyonu kullanabiliriz.

            var kitaplar = await context.Kitaplar.Include(k=> k.Yazarlar).AsNoTrackingWithIdentityResolution().ToListAsync();

            //AsNoTrackingWithIdentityResolution fonksiyonu ASNoTracking fonksiyonuna nazaran görece 
            //yavaştır/maliyetlidir lakin Change Tracker' a nazarandaha performanslı ve az maliyetlidir.
            #endregion

            #region AsTracking
            //Context üzerinden gelen dataları Change Tracker tarafından takip edilmesini iradeli bir 
            //Şekilde ifade etmemizi sağlayan fonksiyondur.

            //// Peki Niye Kullanalım?
            //Bir sonraki inceleyeceğimiz UseQueryTrackingBehavion metodunu davranışı gereği uyhulama 
            //seviyesinde Change Tracker' ın default olarak devrede olup olmamasını ayarlıyor olacağız.
            //Eger ki default olarak pasif hale getirilirse böyle durumda takip mekanizmasını ihtiyaç 
            //olduğu sorgularda AsTracking fonksiyonunu kullanabilir ve böylece takip mekanizmasını
            // iradeli bir şekilde devreye sokmuş oluruz

            var kitaplar1 = await context.Kitaplar.AsTracking().ToListAsync();
            #endregion

            #region UseQueryTrackingBehavion
            //Ef Core seviyesinde/uygulama seviyesinde ilgili contextten gelen verilerin üzerinden  Change Tracker
            //mekanizmasının davranışı temel seviyede belirlememizi sağlayan fonksiyondur. Yani
            //konfigürasyon fonksiyonudur.

            //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); tanımlıyoruz 
            #endregion
        }

        public class ETicaterContext : DbContext
        {
            public DbSet<Kullanici> Kullanicilar { get; set; }
            public DbSet<Rol> Roller { get; set; }
            public DbSet<Kitap> Kitaplar { get; set; }
            public DbSet<Yazar> Yazarlar { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // Provider
                //ConnectionString
                //Lazy Loading
                //vb. amaçlar için kullanır.

                optionsBuilder.UseSqlServer("Server= localhost,1433;Database=ECommerceDb;User Id sa;Passoword =1q2w3e4r+!");

                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }
        public class Kullanici
        {
            public int Id { get; set; }
            public string KullaniciAdi { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Roller { get; set; }
        }

        public class Rol
        {

        }

        public class Kitap
        {
            public  Kitap() => Console.WriteLine("Kitap nesnesi oluşturuldu.");

            public int Id { get;set; }
            public string KitapAdi { get; set; }
            public int SayfaSayisi { get; set; }

            public ICollection<Yazar> Yazarlar { get; set; }


        }

        public class Yazar
        {
            public Yazar() => Console.WriteLine("Yazar nesnesi oluşturuldu.");
            public int Id { get; set; }
            public string YazarAdi { get; set; }
            public ICollection<Kitap> Kitaplar { get; set; }

        }
    }
}