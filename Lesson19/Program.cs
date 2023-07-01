using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Lesson19
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

            #region Change Tracking Neydi?
            //Context nesnesi üzerinden gelen tüm nesneler/veriler otomatik olarak bir takip mekanizması tarafından izlenirler.
            //İşte bu takip mekanizmasına Change Tracker denir. Traker ile nesneler üzerindeki değişiklikler/işlemler takip edilerek
            //netice itibariyle bu işlemlerin fıtratına uygun sql sorgucukları generate edilir. İşte bu işleme de Change Trackin denir.
            #endregion

            #region ChangeTracker Propertysi
            // Takip edilen nesnelere erişebilmemizi sağlaan ve gerektiği taktirde işlemler gerçekleştirmemizi sağlayan bir propertydir.
            //Context sınıfının base class'ı olan DbContext sınıfının bir memner'ıdır.

            var urunler = await context.Urunler.ToListAsync();
            urunler[6].Fiyat = 123; // Update 
            context.Urunler.Remove(urunler[7]); //Delete
            urunler[8].UrunAdi = "zxczxc";//Update

            var date = context.ChangeTracker.Entries();

            #region DetecChanges Metodu
            /*
              
             * EF Core, context mesmesi tarafından izlenen tüm nesnelerdeki değişiklikleri Change Tracker sayesinde takip
               edebilmek ve nesnelerde olan verisel değişiklikleri yakalanarak bunların anlık görüntüleri(snapshot)' ini 
               oluşturabilir.
              
             * Yapılan değişikliklerin veri tabanına gönderilmeden önce algılandığından emin olmak gerekir. SaceChanges
               fonksiyonu çağrıldığı anda nesneler EF Coretrafından otomatik kontrol edilirler.
              
             * Ancak, yapılan operasyonlarda güncel tracking verilerinden emin olabilmek için değişiklerin algılanmasını opsiyonel
               olarak gerçekleştirmek isteyebiliriz. işte bunun için DetectChanges fonksiyonu kullanılabilir be her ne kadar Ef Core
               değilikleri otomatik algılıyor olsa da siz yine de iradenizle kontrole zorlayabilirsiniz
               
              */

            var urun = await context.Urunler.FirstOrDefaultAsync();
            urun.Fiyat = 123;

            context.ChangeTracker.DetectChanges();
            await context.SaveChangesAsync();

            #endregion

            #region AutoDetectChangesEnabled Property'si
            /*
             
             * İlgili metotları(SaveChanges, Entries) tarafından DetectChanges metotdunun otomatik olarak tekiklenmesi
               konfigürasyonunu yapmamızı sağlayan propertydir.
               
             * SaveChanges fonksiyonu tetiklendiğinde DetectChanges metodunu içerisinde default olarak çağırmaktadır.
               Bu durumda DetectChanges fonksiyonunun kullanımını irademizle yönetmek ve maliyer/performans optimizasyonu
               yapmak istediğimiz durumlarda AutoDetectChangesEnabled özelliğini kapatabiliriz.
              
            */
            #endregion

            #region Entries Metodu
            /*
             - Context' te ki Entry metotdunun koleksiyonel versiyonudurç
             - Change Tracker mekanizması tarafından izlenen her entity nesnesinin bilgisini EntityEntry türümden
               elde etmemizi sağlar ve belirli işlemler yapabilmemize olanak tanır.
            - Entries  metodu, DetectChanges metodunu tetikler. Bu durum da tıpkı SaveChanges' da olduğu gibi bir maliyettir.
              Buradaki maliyetten kaçınmak için AutoDetectChangesEnabled özelliğine false değeri verilebilir.

             
             */

            var urunler1 = await context.Urunler.ToListAsync();
            urunler.FirstOrDefault(u => u.Id == 7).Fiyat = 123; //Update
            context.Urunler.Remove(urunler.FirstOrDefault(u=>u.Id==8)); //Delete
            urunler.FirstOrDefault(u => u.Id == 9).UrunAdi = "asdas";//Update

            context.ChangeTracker.Entries().ToList().ForEach(e =>
            {
                if (e.State == EntityState.Unchanged)
                {
                    //:...
                }
                else if (e.State == EntityState.Deleted)
                {
                    //: ....
                }

            });
            #endregion

            #region AccepAllChanges Metodu
            // SaveChanges() veya SaveChanges(true) tetiklendiğinde EF Core herşeyin yolunda olduğunu varsayarak track ettiği verilerin
            // takibini keser yeni değişikliklerin takip edilmesini bekler. Böylece bir durumda beklenmeyen bir durum/ olası bir hata söz
            // konusu olursa EF Core takip ettiği nesnelerin bırakacağı için bir düzeltme mevzu bahis olmayacaktır. 


            //Haliyle bu durumda devreye SaveChanges(false) ve AcceptAllChanges metotları girecektir.

            //SaveChanges(false), EF Core' a gerekli veritabanı komutlarını yürütmesini saöyler ancak gerektiğinde yeniden
            //oynatılabilmesi için değilikleri beklemeye/nesneleri takip etmeye devam eder. taa ki AcceptAllChanges metodu 
            //irademizle çağırana kadar.

            //SaveChanges(false) ile işlemin başarılı olduğundan emin olursanız AccepAllChanges metodu ile nesnelerden takibi kesebilirsiniz

            var urunler2 = await context.Urunler.ToListAsync();
            urunler.FirstOrDefault(u => u.Id == 7).Fiyat = 123; //Update
            context.Urunler.Remove(urunler.FirstOrDefault(u => u.Id == 8)); //Delete
            urunler.FirstOrDefault(u => u.Id == 9).UrunAdi = "asdas";//Update

            //await context.SaveChangesAsync();
            //await context.SaveChangesAsync(true);

            await context.SaveChangesAsync(false);
            context.ChangeTracker.AcceptAllChanges();


            #endregion

            #region HasChanges Metodu
            // Takip edilen nesneler arsından değişiklik olup olmadığını verir.
            // Arka planda DeteChanges metodunu tetikler.
            var result = context.ChangeTracker.HasChanges();
            #endregion
            #endregion

            #region Entity States
            //Entity nesnelerini durumlarını ifade eder.

            #region Detached
            // Nesnelerin change tracker mekanizması tarafından takip edilmediğini ifade eder.
            Urun urun1 = new();
            Console.WriteLine(context.Entry(urun1).State);
            urun1.UrunAdi = "fsadfas";
            await context.SaveChangesAsync();

            #endregion

            #region Added
            //Veri tabanına eklenecek nesneyi ifade eder. Added henüz veri tabanına işlenmeyen veriyi ifade eder.
            //SaveChanges fonksiyonu çağrıldığında insert sorgusu oluşturucaği anlamına gelir.

            Urun urun2 = new(){ Fiyat = 123, UrunAdi = "ürün 72"};
            Console.WriteLine(context.Entry(urun2).State);
            await context.Urunler.AddAsync(urun2); // Added
            Console.WriteLine(context.Entry(urun2).State);
            urun2.Fiyat = 72; //Modified
            Console.WriteLine(context.Entry(urun2).State);
            await context.SaveChangesAsync();
            #endregion

            #region Unchanged
            // Veri tabanundan sorgulandığından beri nesne üzer,nde herhangi bir değişiklik yapılmadığını ifade eder. 
            // Sorgu neticesinde elde edilen tüm nesneler başlangıçta bu state değerindedir. 

            var urunler3 = await context.Urunler.ToListAsync();
            var data1 = context.ChangeTracker.Entries();
            #endregion

            #region Modified
            // Nesne üzerinde değişiklik/ güncelleme yapıldığını ifade eder. SaveChanges fonksiyonu çağrıldığında 
            //update sorgusu oluşturacağı anlamına gelir.

            var urun3 = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
            Console.WriteLine(context.Entry(urun3).State);//Unchanged
            urun3.UrunAdi = "sadas";
            Console.WriteLine(context.Entry(urun3).State);//Modified
            await context.SaveChangesAsync(); //Eger SaveChangesAsync(false); yaparsak Modified olur
            Console.WriteLine(context.Entry(urun3).State);//Unchanged
            #endregion

            #region Deleted
            // Nesnenin silindiğini ifade eder. Savechanges fonksiyonu çağrıldığında delete sorgusu oluşturulacağı anlamına gelir.

            var urun4 = await context.Urunler.FirstOrDefaultAsync(u=> u.Id ==3);
            context.Urunler.Remove(urun4);
            context.SaveChangesAsync();
            #endregion

            #endregion

            #region Context Nesne Üzerinden Tacker
            //
            var urun5 = await context.Urunler.FirstOrDefaultAsync(u=>u.Id ==72);
            urun5.Fiyat = 123;
            urun5.UrunAdi = "Halı"; //Modified | Update

            #region Entry Metodu

            #region OriginalValues Property'si
            var fiyat = context.Entry(urun5).OriginalValues.GetValue<float>(nameof(urun5.Fiyat));
            var urunAdi = context.Entry(urun5).OriginalValues.GetValue<string>(nameof(urun5.UrunAdi));
            #endregion

            #region CurrentValues Property' si
            var urunAdi1 = context.Entry(urun5).CurrentValues.GetValue<string>(nameof(urun5.UrunAdi));// Mevcut değerini elde ettik
            #endregion

            #region GetDatabaseValues Metodu
            var urunAdi2 = context.Entry(urun5).GetDatabaseValuesAsync();
            #endregion

            #endregion

            #endregion

            #region Change Track' ın Interceptor Olarak Kullanılması

            #endregion
        }
        public class EticaterContext : DbContext
        {
            public DbSet<Urun> Urunler { get; set; }
            public DbSet<Parca> Parcalar { get; set; }
            public DbSet<UrunParca> urunParca { get; set; }



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
                modelBuilder.Entity<UrunParca>().HasKey(up => new { up.UrunId, up.ParcaId });
            }

            public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            {
                var entries = ChangeTracker.Entries();
                foreach(var entry in entries)
                {
                    if (entry.State == EntityState.Added)
                    {

                    }
                }
                return base.SaveChangesAsync(cancellationToken);
            }
        }


        public class Urun
        {
            public int Id { get; set; }
            public string UrunAdi { get; set; }
            public float Fiyat { get; set; }
            public ICollection<Parca> Parcalar { get; set; }
        }
        public class Parca
        {
            public int Id { get; set; }
            public string ParcaAdi { get; set; }


        }
        public class UrunParca
        {
            public int UrunId { get; set; }
            public string ParcaId { get; set; }
            public Urun Urun { get; set; }
            public Parca Parca { get; set; }
        }
        public class UrunDetay
        {
            public int Id { get; set; }
            public float Fiyat { get; set; }
        }
    }
}