using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lesson13
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
            #region En Temel Basit Bir Sorgulama Nasıl Yapılır?
            #region Method Syntax
            var urunler = await context.Urunler.ToListAsync();
            #endregion
            #region Query Syntax
            #endregion
            var urunler2 = await (from urun in context.Urunler select urun).ToListAsync(); // c# üzerinden bir select sorgulaması yapmış oluyoruz
            #endregion
            #region Sorguyu Execute Etmek için ne Yapmamız Gerekmektedir?
            #region ToListAsync

            //1) Method Syntax
            //2) Query Syntax
            #endregion
            int urunId = 5;
            string urunAdi = "2";
            var urunler3 = from urun in context.Urunler where urun.Id > urunId && urun.UrunAdi.Contains(urunAdi) select urun; // bu durum execute edilmeden çalışmıyor. Ertelenmiş çalışma olarak anlayabilirsin
            urunId = 200; // Deferred Execution dolayı 200 den başlar 
            urunAdi = "4"; // Deferred Execution dolayı ürün adı 4 içerenleri alır. 
            foreach (Urun urun in urunler3)
            {
                Console.WriteLine(urun.UrunAdi);
            }

            await urunler3.ToListAsync(); //ile de aynı foreach gibi Deferred Execution sağlanıyor.
            #region Foreach
            //foreach (Urun urun in urunler3)
            //{
            //    Console.WriteLine(urun.UrunAdi);
            //}
            #region Deferred Execution(Ertelenmiş Çalışma)
            // IQueryable çalışmalarında ilgili kod yazıldığı noktada tetiklenmez/çalıştırılmaz yani ilgili kod yazıldığı noktada sorguyu generate etmez!
            //Nerede Eder? Çalıştırıldığı / execute edildiği noktada tetiklenir1 işte bu durumda ertelemiş çalışma denir!
            #endregion
            #endregion
            #endregion
            #region IQueryable ve IEnumerable Nedir ? Basit Olarak!
            var urunler1 = from urun in context.Urunler select urun;
            // IQueryable : Sorguya karşılık gelir. Ef Core üzerinden yapılmış olan sorgunun execute edilmiş halini ifade eder.
            // IEnumerable : Sorgunun çalıştırılıp / execute edilip verilerin in memorye yüklenmiş halini ifade eder.
            #endregion
            #region Çoğul Veri Getiren Sorgulama fonksiyonları
            #region ToListAsync
            //Üretilen sorguyu execute ettirmemizi sağlayan fonksiyondur.

            #region Method Syntax
            var urunler4 = context.Urunler.ToListAsync();
            #endregion

            #region Query Syntax
            //1. Yol olarak
            var urunler5 = (from urun in context.Urunler select urun).ToListAsync();

            //2. Yol olarak
            var urunler6 = from urun in context.Urunler select urun;
            var datas = await urunler6.ToListAsync();
            #endregion
            #endregion
            #region Where Fonksiyonu
            //Oluşturulan sorguya where şartı eklemenizi sağlayan bir fonksiyondur.
            #region Methode Syntax
            // var urunler7 = context.Urunler.Where(u => u.Id > 500).ToListAsync();
            var urunler7 = context.Urunler.Where(u => u.UrunAdi.StartsWith("a")).ToListAsync();
            #endregion
            #region Query Syntax
            var urunler8 = from urun in context.Urunler
                           where urun.Id > 500 && urun.UrunAdi.EndsWith("7")
                           select urun;
            var data2 = await urunler8.ToListAsync();
            #endregion
            #endregion
            #region OrderBy Fonksiyonu
            // Sorgu üzerinde sıralama yapmamızı sağlayan bir fonksiyondur.
            #region Method Syntax
            var urunler9 = context.Urunler.Where(u => u.Id > 500 || u.UrunAdi.EndsWith("2")).OrderBy(u => u.UrunAdi);
            #endregion

            #region Query Syntax
            var urunler10 = (from urun in context.Urunler
                             where urun.Id > 500 || urun.UrunAdi.StartsWith("2")
                             orderby urun.UrunAdi ascending
                             select urun);

            #endregion
            await urunler9.ToListAsync();
            await urunler10.ToListAsync();
            #region ThenBy Fonksiyonu
            // OrderBy üzerinden yapılan sıralama işlemini farklı kolonlara uygulamamızı sağlayan bir fonksiyondur. (Ascending)
            var urunler11 = context.Urunler.Where(u => u.Id > 500 || u.UrunAdi.EndsWith("2")).OrderBy(u => u.UrunAdi).ThenBy(u => u.Fiyat).ThenBy(u => u.Id);
            await urunler11.ToListAsync();
            #endregion
            #endregion
            #region OrderByDescending Fonksiyonu
            // Sıralma işlemlerinde descending olarak sıralama yapan bir donksiyondur
            #region Method Syntax
            var urunler13 = await context.Urunler.OrderByDescending(u => u.Fiyat).ToListAsync();
            #endregion
            #region Query Syntax
            var urunler14 = await (from urun in context.Urunler
                                   orderby urun.UrunAdi descending
                                   select urun).ToListAsync();
            #endregion
            #endregion
            #region ThenByDescending
            // OrderByDescending üzerinden yapılan sıralma işlemini farklı kolonlarda uygulamamızı sağlayan bir fonksiyondur. ( Ascending)
            var urunler15 = context.Urunler.OrderByDescending(u => u.Id).ThenByDescending(u => u.Fiyat).ThenBy(u => u.UrunAdi).ToListAsync();
            #endregion
            #endregion
            #region Tekil Veri Getiren Sorgulama Fonksiyonları

            // Yapılan sorguda sade ve sadece tek bir verinin gelmsi amaçlanıyorsa Single ya da SingleOrDefault fonksiyonları kullanılabilir. 
            #region SingleAsync
            // Eğer ki, sorgu neticesinde birden fazla veri geliyorsa ya da hiç veri gelmiyorsa iki durumda exeption fırlatır.
            #region Tek Kayıt Geldiğinde
            var urun1 = await context.Urunler.SingleAsync(u => u.Id == 72);
            #endregion
            #region Hiç Kayıt Gelmediğinde
            var urun2 = await context.Urunler.SingleAsync(u => u.Id == 5555);
            // Yukarıdaki kodu çalıştırdığımızda veri tabanında hata vermiyor. Fakat kodda hata fırlatıyor çünkü veri tabanında Id = 5555 olan bir ürün yok
            #endregion
            #region Çok kayıt Geldiğinde 
            var urun3 = await context.Urunler.SingleAsync(u => u.Id > 72);
            // yukarıda ki kod aynı şekilde birden fazla veri getiriyor SingleAsync fonksiyonu kullandığımız için kodda hata fırlatıyor. 
            #endregion
            #endregion
            #region SingleOrDefaultAsync
            // Eğer ki, sorgu neticesinde birden fazla veri geliyorsa exeption fırlatır, hiç veri gelmiyorsa null döner.
            #region Tek Kayıt Geldiğinde
            var urun4 = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 72); // Id == 72 olan tek bir ürün olduğu için hata gelmiyor
            #endregion
            #region Hiç Kayıt Gelmediğinde
            var urun5 = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 5555); //Id == 5555 olan urun olmadığı için null olarak döner

            #endregion
            #region Çok kayıt Geldiğinde 
            var urun6 = await context.Urunler.SingleOrDefaultAsync(u => u.Id > 72);
            // yukarıda ki kod aynı şekilde birden fazla veri getiriyor SingleOrDefaultAsync fonksiyonu kullandığımız için kodda hata fırlatıyor. 
            #endregion
            #endregion


            // Yapılan sorguda tek bir verinin gelmesi amaçlanıyorsa First ya da FirstOrDefault fonksiyonları kullanılır.
            #region FirsAsync
            // Sorgu neticesinde elde edilen verilerden ilkini getirir. Eğer ki veri gelmiyorsa hata fırlatır.

            #region Tek kayır Geldiğinde
            var urun7 = await context.Urunler.FirstAsync(u => u.Id == 55);// tek veri geliyorsa veri gelir.
            #endregion
            #region Hiç Kayıt Gelmiyorsa
            var urun8 = await context.Urunler.FirstAsync(u => u.Id == 55555); // hata fırlatır.
            #endregion
            #region Çok Kayıt Geliyorsa
            var urun9 = await context.Urunler.FirstAsync(u => u.Id > 55); // veri tabanında ne kadar veri varsa elde edecek ve bunlardan ilkini bize getirecek
                                                                          // Eğer hiç veri gelmese hata fırlatacak
            #endregion
            #endregion
            #region FirstOrDefaultAsync
            //Sorgu neticesinde elde edilen verilerden ilkini getirir. Eğer ki veri gelmiyorsa null değerini döndürür.
            #region Tek kayır Geldiğinde
            var urun10 = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 55);// tek veri geliyorsa veri gelir.
            #endregion
            #region Hiç Kayıt Gelmiyorsa
            var urun11 = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 55555); // null Değerei döndürür.
            #endregion
            #region Çok Kayıt Geliyorsa
            var urun12 = await context.Urunler.FirstOrDefaultAsync(u => u.Id > 55); // veri tabanında ne kadar veri varsa elde edecek ve bunlardan ilkini bize getirecek
                                                                                    // Eğer hiç veri gelmese hata fırlatacak
            #endregion

            #endregion


            #region SingleAsync, SingleORDefaultAsync, FirstAsync, FirstOrDefaultAsync karşılaştırılması
            /**************************************************************************************************
             *         ŞARTLAR        | SingleAsync | SingleOrDefaultAsync | FirstAsync  | FirstOrDefaultAsync |
             * ***********************|*************|**********************|*************|*********************|
             * Hiç Kayıt Gelmediğinde | Exeption    | Null Döner           | Exeption    | Null Döner          |
             * ***********************|*************|**********************|*************|*********************|
             * Tek Kayıt Geldiğinde   | Döndürür    | Döndürür             | Döndürür    | Döndürür            |
             * ***********************|*************|**********************|*************|*********************|
             * Çok kayıt Geldiğinde   | Exeption    | Exeption             | 1. Döndürür | 1. Döndürür.        |
             * ***********************|*************|**********************|***********************************|
             * */

            #endregion

            #region FindASync
            // Find fonksiyonu primary key kolonuna özel hızli bir şekilde sorgulama yapmanızı sağlayan bir fonksiyondur.

            //var urun13 = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 55); kullanmak yerine
            var urun13 = await context.Urunler.FindAsync(55); // Find fomksiyonu kullanarak kısa bir şekilde ifade edebilirsin

            #region Composite Primary Key Durumu 
            UrunParca u = await context.urunParca.FindAsync(2, 5);
            #endregion
            #endregion

            #region FindAsync ile SingleAsync, SingleOrDefaultAsync, FirstAsync, FirstOrDefaultAsync Fonksiyonlarının karşılaştırılması
            /*
             * FindAsync Fonksiyonu : 
             * 1- Sorgulama sürecince önce contect içerisini kontrol eder, kaydı bulamadığı taktirde sorguyu veritabanına gönderir.
             * 2- Yanlız primary key alanlarını sorgulayabilir.
             * 3- Kayıt bulunamazsa null döndürür
             * 
             * SingleAsync, SingleOrDefaultAsync, FirstAsync, FirstOrDefaultAsync Fonksiyonları : 
             * 1- Sorguyu her zaman veri tabanına gönderir.
             * 2- Tüm kolonları where cümleciği eşliğinde sorguklayabilir.
             * 3- SingleAsync ve FirstAsync exeption fırlatır. SingleOrDefaultAsync ve FirstOrDefaultAsync ise null dönderir.
             * 
             * */
            #endregion

            #region LastAsync
            // Sorgu neticesinde gelen verilerden en sonuncusunu getirir. Eğer ki hiç veri gelimiyorsa hata fırlatır.  OrderBy kullanmak mecburidir.
            var urun15 = await context.Urunler.OrderBy(u => u.Fiyat).LastAsync(u => u.Id > 55);
            #endregion

            #region LastOrDefaultAsync
            // Sorgu neticesinde gelen verilerden en sonuncusunu getirir. Eğer ki hiç veri gelimiyorsa null döner.  OrderBy kullanmak mecburidir.
            var urun16 = await context.Urunler.OrderBy(u => u.Fiyat).LastAsync(u => u.Id > 55);
            #endregion

            #endregion
            #region Diğer Sorgulama Fonksiyonları
            #region ContAsync
            // Oluşturulan Sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(int) 
            // bizlere bildiren fonksiyondur.
            // var urunlerr = (await context.Urunler.ToListAsync()).Count(); Bu işlem çok maliyetli bundan dolayı aşağıdaki işlemi uygulayalım
            var urunlerr = await context.Urunler.CountAsync(); // Bu işlem maliyet olarak daha uygun çünkü  direk sonucu alıyoruz 
            #endregion

            #region LongCountAsync
            // Oluşturulan Sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak (long) 
            // bizlere bildiren fonksiyondur.
            var urunlerr1 = await context.Urunler.LongCountAsync();
            //   var urunlerr1 = await context.Urunler.LongCountAsync(u=> u.Fiyat > 500); Şeklinde Şartlı bir yapı da oluşturulabilir.
            #endregion

            #region AnyAsync
            //Sorgu  neticesinde verinin gelip gelmediğini bool türünden dönen fonksiyondur.
            var urunlerr2 = await context.Urunler.AnyAsync();
            // var urunlerr2 = await context.Urunler. Where(u = u.UrunAdi.Contains("1")).AnyAsync(); şeklinde Where fonksiyonu da kullanılabilir.
            //var urunlerr2 = await context.Urunler.AnyAsync(u = u.UrunAdi.Contains("1")); Where fonksiyonu kullanmadan da şart işlemlerini yapabilirsin
            #endregion

            #region MaxAsync
            //Verilen kolonlardaki max değeri verir.
            var fiyat = await context.Urunler.MaxAsync(u => u.Fiyat); // En yüksek Fiyatı verir.
            #endregion

            #region MinAsync
            // Verilen kolonlardaki min değeri verir.
            var fiyat1 = await context.Urunler.MinAsync(u => u.Fiyat); // En düşük Fiyatı verir.
            #endregion

            #region Distinct
            //Sorguda mükerrer kayıtlar varsa bunları tekilleştiren bir işleve sahip fonksiyondur.
            var urunlerr3 = await context.Urunler.Distinct().ToListAsync();
            #endregion

            #region AllAsync
            // Bir sorgu neticesinde gelen verilerin, verilen şarta uyup uymadığını kontrol etmektedir. 
            // Eğer ki tüm veriler şarta uyuyorsa true, uymuyorsa false dönecektir.
            var fiyatt = context.Urunler.AllAsync(u => u.Fiyat > 5000);

            #endregion

            #region SumAsync
            // Vermiş olduğumuz sayısal proprtynin toplamını alır.
            var fiyatToplam = await context.Urunler.SumAsync(u => u.Fiyat);
            #endregion

            #region AverageAsync
            //Vermiş olduğumuz sayısal proeprtynin aritmatik ortalamasını alır.
            var aritmetikOrtalama = await context.Urunler.AverageAsync(u => u.Fiyat);
            #endregion

            #region ContainsAsync
            // Like '%...%' sorgusu oluşturmamızı sağlar.
            var urunlerr4 = await context.Urunler.Where(u => u.UrunAdi.Contains("72")).ToListAsync();
            #endregion

            #region StartsWith
            // Like '...%' sorgusu oluşturmamızı sağlar.
            var urunlerr5 = await context.Urunler.Where(u => u.UrunAdi.StartsWith("72")).ToListAsync();
            #endregion

            #region EndssWith
            // Like '%...' sorgusu oluşturmamızı sağlar.
            var urunlerr6 = await context.Urunler.Where(u => u.UrunAdi.EndsWith("72")).ToListAsync();
            #endregion

            #endregion
            #region Sorgu Sonucu Dönüşüm Fonksiyonları 
            //Bu fonksiyonlar ile sorgu neticesinde elde edilen verileri isteğimiz doğrultusunda farklı türlerde projecsiyon edebiliyoruz

            #region ToDictionaryAsync
            // Sorgu neticesinde gelecek olan veriyi bir dictionry olarak elde etmek / tutmak / karşılamak istiyorsal eğer kullanılır.

            var urunlerrr = await context.Urunler.ToDictionaryAsync(u => u.UrunAdi, u => u.Fiyat);

            // ToList ile aynı amaca hizmet etmektedir. Yani, oluşturulan sorguyu execute edip neticesini alırlar.
            // ToList : Gelen sorgu neticesinde entity türünde bir koleksiyona(List < TEntity >) dönüştürmekteyken, 
            // ToDictionary ise : Gelen sorgu neticesini Dictionary türünden bir koleksiyona dönüştürecektir.
            #endregion

            #region ToArrayAsync
            // Oluşturulan sorguyu dizi olarak elde eder.
            // ToList ile muadil amaca hizmet eder.  Yani sorguyu execute eder lakin gelen sonucu entity dizisi olarak elde eder.
            var urunlerrr2 = await context.Urunler.ToArrayAsync();
            #endregion

            #region Select
            // Select fonksiyonun işlecsel ola birden fazla davranışı söz konusudur.

            // 1-Select fonksiyonu, generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır.
            var urunlerrr3 = await context.Urunler.Select(u => new Urun { Id = u.Id, Fiyat = u.Fiyat }).ToListAsync();

            //2- Select fonksiyonu, gelen verileri farklı türlerde karşılamamızı sağlar. T, anonim

            var urunlerrr4 = await context.Urunler.Select(u => new { Id = u.Id, Fiyat = u.Fiyat }).ToListAsync(); // anonim yapı

            var urunlerrr5 = await context.Urunler.Select(u => new UrunDetay { Id = u.Id, Fiyat = u.Fiyat }).ToListAsync();
            #endregion

            #region SelectMany
            // Select ile aynı amaca hizmet eder. Lakin, ilişkisel tablolar neticesinde gelen koleksiyonel verileri de tekilleştirip projeksiyon etmemizi sağlar. 

            var urunlerrr6 = await context.Urunler.Include(u => u.Parcalar).SelectMany(u => u.Parcalar, (u, p) => new { u.Id, u.Fiyat, p.ParcaAdi }).ToListAsync();
            #endregion

            #endregion
            #region GroupBy Fonksiyonu
            //Gruplama yapmamızı sağlayan fonksiyondur.

            #region Method Syntax
            var datas1 = await context.Urunler.GroupBy(u => u.Fiyat).Select(group => new { Count = group.Count(), Fiyat = group.Key }).ToListAsync();
            #endregion
            #region Query Syntax
            var datas2 = await  (from urun in context.Urunler
                                 group urun by urun.Fiyat
                                 into @group
                                select new { Fiyat = @group.Key, Count = @group.Count() }).ToListAsync();
            #endregion

            #endregion
            #region Foreach Fonksiyonu
            // Bir sorgulama fonksiyonu değildir!
            // Sorgulama neticesinde elde edilen koleksiyonel veriler üzerinde iterasyonel olarak dönmemizi ve 
            // teker teker verileri elde edip işlemler yapabilmemizi sağlayan bir fonksiyondur.
            //foreach döngüsünün metot halidir!

            foreach(var item in datas1)
            {

            }

            datas1.ForEach(x =>
            {

            });
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