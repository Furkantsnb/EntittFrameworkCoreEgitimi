# Entity Framework Core Egitimi
ORM yaklaşımı ile Entity Framework Core eğitimini görerek hazırladığım notlar için öncelikle " Gençay Yıldız " @gncyyldz  Hocamıza  
emeği ve anlatımı için çok TEŞEKKÜR EDERİM...  

EF Core Dersinin oynatma listesi : https://www.youtube.com/playlist?list=PLQVXoXFVVtp1o3nq3-IXv42bPaFlzroBE

Derslerin adım adım tüm notlarını konu başlıklarını inceleyerek tekrar edebilirsiniz :)

# Entity Framework Core Ders #4 - EF Core Neden Tercih Edelim? Kullanım İçin Neler Yüklemeliyiz


📌 **EF CORE NEDİR ?**

</aside>

- EF Core, ORM yaklaşımını benimsemiş bir araçtır.
- Kod içerisinde OOP istifade ederek OOP sorguları oluşturmamızı sağlamaktadır.
- Açık kaynaktır (Open source), esnek ve geliştirilebilir.
- Kod içerisinde ihtiyaca binaen geliştirilmiş olan tekrarlı SQL sorgucuklarından kurtarmaktadır.
- Code First ve Database First yaklaşımları eşliğinde veri tabanı ile yazılım arasındaki koordinasyonu sağlamaktadır.
- Kod üzerinden;
    - Veri tabanı ve tabloları,
    - Constraint,
    - Sequence,
    - İlişkili sorgular,
    - View
    - Stored Procedure
    - Function
    - Temporal Table

Gibi veri tabanı nesneleri oluşturmamızı ve kullanmamızı sağlamaktadır.

Query ve LINQ sorgularını desteklemektedir.

<aside>
📌 **EF CORE NASIL YÜKLENİR**

</aside>

- **Yüklenecek Araçlar;**
    - .NET Core command-line interface(CLI) tools
        - dotnet-efe ile başlayan CLI komutlarını ilgili PC de aktif olarak kullanabilmemizi sağlayan tool’dur.
        - Install= dotnet tool install —global dotnet-ef
        - Update= dotnet tool update —global dotnet-ef
        
        yüklemeyi yaptıktan sonra kontrol etmek içi chek edebiliriz;
        
        - Check = dotnet ef
        - Tool’ u yükledikten sonra belirli bir projede kullanabilmek için ilgili projede şu {Microsoft.EntityFraneworkCore.Design} paketin de yüklü olması gerekmektedir.
        - 
    
    - Package Manager Console (PMC) tools
        - Visual Studio, Package Manager Console üzerinden talimatlar vermemizi sağlayan bir tool’dur.
        - Haliyle Package Manager Console üzerinden talimatları verebilmek için şu            {Microsoft.EntityFraneworkCore.Tools} paketin ilgili projede yüklü olması gerekmektedir.
        
</aside>



# Entity Framework Core Ders #5 - Database First ve Code First Yaklaşımları Nelerdir? Teorik inceleyelim

<aside>
📌 EF Core, Veri tabanlarıyla iki farklı yaklaşımı baz alarak çalışmalar sergilemektedir. Bu yaklaşımlar;

**Database First —>Önce veri tabanı, sonra kod**  

**Code First —> Önce kod sonra ,veri tabanı**

olmak üzere ikiye ayrılır.

<aside>
📌 **Peki yaklaşım ne demek?**

</aside>

Yaklaşım; bir konu, olguyu, yapıyı, inşayı, sorunu, çözümü ele alış biçimi bir başka değişle ona bütünsel olarak bakış biçimidir.

Veri tabanı doğal olarak mevcut olan bir projeye katıldığınızda Database First yaklaşımı tercih edilir.     Lakin veri tabanı inşa edilmemiş bir projeye katılım gösteriyor olsaydınız bu durumda Database First ya da Code First yaklaşımından birini tercih edebiliriz.


![image](https://github.com/Furkantsnb/EntittFrameworkCoreEgitimi/assets/95514574/0e286608-0f9c-43a8-9a8a-499678048867)

![image](https://github.com/Furkantsnb/EntittFrameworkCoreEgitimi/assets/95514574/55ec5b64-7a1f-437d-a2dc-174ea1ea9d9c)


</aside>


 

# Entity Framework Core Ders #6 - Yapısal Olarak EF Core Aktörleri Nelerdir?


**Veri Tabanı Nesnesi -  DbContext**

![image](https://github.com/Furkantsnb/EntittFrameworkCoreEgitimi/assets/95514574/d9e2902f-57af-407e-8d19-ba37aa1c3a1b)


<aside>
📌 **DbContext Nesnesinin Sorumlu Olduğu Faaliyetler Nelerdir?**

**Konfigürasyon :** Veri tabanı bağlantısı, model yapılanmaları ve veri tabanı nesnesi ile tablo nesneleri arasındaki ilişkileri sağlar.

**Sorgulama :** Sorgulama operasyonlarını yürütür. Kod tarafından gerçekleştirilen sorgulama adımlarını SQL sorgusuna dönüştürür ve veri tabanı gönderir.

**Change tracking :** Sorgulama neticesinde elde edilen veriler üzerindeki değişiklikleri takip eder.

**Veri Kalıcılığı :** Verilerin kayıt edilmesi, güncellenmesi ve silinmesi operasyonlarını gerçekleştirir.

**Caching**

**Tablo Nesnesi - Entity** 

![image](https://github.com/Furkantsnb/EntittFrameworkCoreEgitimi/assets/95514574/479a1ec1-d456-452d-a3b0-7f2929fa354a)


Dikkat! Veri tabanında tablo adı çoğul olur, lakin o entity sınıfının adı tekil olur. 

```jsx
public class NothwindDbContext : DbContext
{
  public DbSet<Employee>Employees{get;set;}
  public DbSet<Order>Orders{get;set;}
  public DbSet<Category>Categorys{get;set;}
  public DbSet<Customer>Customers{get;set;}
  public DbSet<Supplier>Suppliers{get;set;}
  public DbSet<Product>Products{get;set;}

}
```

Tüm entity sınıfları DbContext sınıfı içerisinde DbSet olarak eklenmelidir. Böylece veri tabanı sınıfı ile entity sınıfları arasında bir ilişki kurulacak ve EF Core temsil ettiğini bu ilişki üzerinden anlayacaktır.

Ayrıca bu DbSet property isimlerinin çoğul olduğuna dikkat ediniz, Entity sınıfları tekil isimken, bu entity sınıfı türüne karşılık gelen tabloyu temsil eden property çoğul isimli olmalıdır. 

**Tablo Kolonları**

![image](https://github.com/Furkantsnb/EntittFrameworkCoreEgitimi/assets/95514574/382b9a5a-14b9-40aa-86a6-42c8b80caac6)


Bir entity içerisindeki propertyler, o entity’nin modellediği tablo içerisindeki kolonlara karşılık gelmektedir!

**Veriler**

![image](https://github.com/Furkantsnb/EntittFrameworkCoreEgitimi/assets/95514574/83a25e69-4d8d-41cd-a469-07c6721f841c)


</aside>

</aside>




# Entity Framework Core Ders #7 - Database First Yaklaşımını Pratikte İnceleyelim


📌 **PMC ile Tersine Mühendislik**

</aside>

Gerekli siteler aşağıda olan linklerden ulaşabilirsiniz

- https://www.connectionstrings.com/
    
    https://learn.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli
    

Aşağıda olan formatta connection strings kullanacaksın

- Server=myServerAddress;Database=myDataBase;User Id = myUsername;Password = myPassword;

- Scaffold-DbContext ‘Connection String’ Microsoft.EntityFrameworkCore.[Provider]
- PMC ile  veri tabanını modelleyebilmek için aşağıdaki kütüphanelerin projeye yüklenmesi gerekmektedir.
    - Microsoft.EntityFrameworkCore.Toolls
    - Database Provider(Örn; Microsoft.EntityFramworkCore.SqlServer)
    

<aside>
📌 **Dotnet CLI ile Tersine Mühendislik**

</aside>

- dotnet ef dbcontext scaffonld ‘Connection String’ Microsoft.EntityFrameworkCore.[Provider]
- Dotnet CLI ile  veri tabanını modelleyebilmek için aşağıdaki kütüphanelerin projeye yüklenmesi gerekmektedir.
    - Microsoft.EntityFrameworkCore.Desing
    - Database Provider(Örn; Microsoft.EntityFramworkCore.SqlServer)

<aside>
📌 **Tabloları Belirtme**

Varsayılan olarak veri tabanındaki tüm tabloları modellenir. Sadece istenilen tabloların modellenebilmesi için aşağıdaki gibi talimatların verilmesi yeterlidir.

- dotnet ef dbcontext scaffonld ‘Connection String’ Microsoft.EntityFrameworkCore.[Provider] —table Table1 — table Table2
- Scaffold-DbContext ‘Connection String’ Microsoft.EntityFrameworkCore.[Provider] -Tables Table1, Table2
</aside>

<aside>
📌 **DbContext Adını Belirtme**

Scaffold ile modellenen veri tabanı için oluşturulacak context nesnesi adını veri tabanında alacaktır. Eğer ki context nesnesinin adını değiştirmek istiyorsanız aşağıdaki gibi çalışabilirsiniz.

- Scaffold-DbContext ‘Connection String’ Microsoft.EntityFrameworkCore.[Provider] -Context ContextName
- dotnet ef dbcontext scaffonld ‘Connection String’ Microsoft.EntityFrameworkCore.[Provider]—context ContextName
</aside>

<aside>
📌 **Path ve Namespace Belirtme**

Entityler ve DbContext sınıfı, default olarak direk projenin kök dizinine modellenir ve projenin varsayılan namespace kullanırlar. Eğer ki bunlara müdahale etmek istiyorsanız aşağıdaki gibi talimat verebilirsiniz.

**Path:** 

- Scaffold-DbContext ‘Connection String’ Microsoft.EntityFrameworkCore.[Provider] -ContextDir Data —OutputDir Models
- dotnet ef dbcontext scaffonld ‘Connection String’ Microsoft.EntityFrameworkCore.[Provider]—context-dir Data —output-dir Models

**NameSpace :** 

- Scaffold-DbContext ‘Connection String’ Microsoft.EntityFrameworkCore.[Provider] -Namespace YourNamespace -ContexNamespace YourNameSpace
- dotnet ef dbcontext scaffonld ‘Connection String’ Microsoft.EntityFrameworkCore.[Provider]                                                                                                                          —namespace YourNamespace
 —context-namespace YourContextNamespace

</aside>

<aside>
📌 **Model Güncelleme**

</aside>

![image](https://github.com/Furkantsnb/EntittFrameworkCoreEgitimi/assets/95514574/a2ec69d6-cad3-49a3-bfa0-dee378eb4d52)


<aside>
📌 **Modellerin Özelleştirilmesi**

</aside>

![image](https://github.com/Furkantsnb/EntittFrameworkCoreEgitimi/assets/95514574/20516761-b13e-4ee5-b6a9-af3b0bdf8b0c)


</aside>




# Entity Framework Core Ders #8 - Code First Yaklaşımını Pratikte İnceleyelim


📌 Migration ve Migrate kavramları Nelerdir ?

</aside>

"Migration” Göç anlamına gelir. “Migrate” ise  göç etmek anlamına gelir 

C# Entity Framework'te "migration" ve "migrate" terimleri veritabanı işlemleriyle ilgili olarak kullanılır. Entity Framework, veritabanı tablolarının ve ilişkilerinin yönetimi için bir ORM (Object-Relational Mapping) aracıdır. Migration, veritabanı şemasındaki değişikliklerin yönetilmesini sağlar.

"Migrations" (migration'lar), Entity Framework tarafından otomatik olarak oluşturulan ve yönetilen sürüm kontrolüne tabi olan veritabanı şema değişikliklerinin birer adımıdır. Bu migration adımları, veritabanını yeni duruma getirmek için gerekli SQL komutlarını içerir.

"Migrate" ise bu migration adımlarının uygulanması anlamına gelir. Bu işlem, mevcut veritabanının migration adımlarına dayanarak güncellenmesini sağlar. Bu sayede, veritabanının şema değişikliklerine uyum sağlaması ve güncel hale gelmesi sağlanır.

Örneklerle açıklamak gerekirse:

1. Migration Oluşturma:
    - "dotnet ef migrations add InitialCreate" komutuyla "InitialCreate" adında bir migration oluşturulur.
    - Bu migration, veritabanında yeni tablolar oluşturmak veya mevcut tablolara sütun eklemek gibi değişiklikleri içerir.
2. Migrate İşlemi:
    - "dotnet ef database update" komutuyla migration'lar veritabanına uygulanır.
    - Bu işlem, oluşturulan migration'ları alır ve veritabanını yeni duruma getirmek için gerekli SQL komutlarını çalıştırır.

Bu örneklerde, "migration" terimi yeni bir veritabanı şema durumunu temsil ederken, "migrate" fiili bu yeni durumu mevcut veritabanına uygulamak için kullanılır. Entity Framework migration mekanizması, veritabanı şema değişikliklerini kolayca yönetmek ve güncellemeleri otomatik olarak uygulamak için kullanışlı bir araçtır.

![image](https://github.com/Furkantsnb/EntittFrameworkCoreEgitimi/assets/95514574/334e8812-b789-43b5-8a32-04e487232362)

<aside>
📌 Migration Oluşturmak için Temel Gereksinimler Nelerdir?

</aside>

Migration oluşturmak için temel Ef Core aktörleri olan dbContext ve Entity class’ların oluştumak gerekir. Bunları oluşturduktan sonra migration Package Manager Console ve Dotnet CLI olmak üzere iki türlü talimatla verilebilir.

```csharp
using Microsoft.EntityFrameworkCore;
namespace Ders8
{
   
    public class EcommerceDbContext : DbContext // Microsoft.EntityFrameworkCore kütüphanesini yükleyin
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //projeye uygun Provider yükleyin ben sqlServer kütüphanesini kullandım
            optionsBuilder.UseSqlServer("Server= localhost,1433;Database=ECommerceDb;User Id sa;Passoword =1q2w3e4r+!");
        }
    }

    //Entity
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public int Quantity { get; set; }
        public float Price { get; set; }
    }

    //Entity
    public class Customer
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }    
    }
}
```

<aside>
📌 Migration Oluşturma

</aside>

- Package Maneger Console
    - add-migration[Migration Name]
- Dotnet CLI
    - dotnet ef migrations add[Migration Name]

<aside>
📌 Migration Path’ i Belirleme

</aside>

- Package Maneger Console
    - add-migration[Migration Name] -OutputDir[Path]
- Dotnet CLI
    - dotnet ef migrations add [Migration Name] —output-dir[Path]

<aside>
📌 Migration Silme

</aside>

- Package Maneger Console
    
    remove-migration
    
- Dotnet CLI
    
    dotnet ef migrations remove
    

<aside>
📌 Migration’ ları Listeleme

</aside>

- Package Maneger Console
    - get-migration
- Dotnet CLI
    - dotnet ef migrations list

<aside>
📌 Migration’ ları Migrate Etme! (Up Fonksiyonu)

</aside>

- Package Maneger Console
    - update-database
- Dotnet CLI
    - dotnet ef database update

<aside>
📌 Migration’ ları Geri Alma (Down Fonksiyonu)

</aside>

- Package Maneger Console
    - update-database[Migration Name]
- Dotnet CLI
    - dotnet ef database update[Migration Name]

Kod Üzerinden Migrate Operasyonu

Migration'lan tool aracılığıyla migrate edebildiğimiz gibi kod Üzerinden de
uygulamanın ayakta olduğu sürece (runtime'da) veri tabanını migrate edebiliyoruz.

```csharp
AppDbContext context = new();
await context.Database.MigrateAsync();
```

<aside>
📌 Son Uyarı

</aside>

- Veri tabanı sınıflan Üzerinde yapılan tüm değişiklikleri migration eşliğinde gönderiniz.  Böylece her bir değişiklikleri migration'lar ile kayıt altına almış
olursunuz (bu da size veri tabanı gelişim sürecini verir) ve ihtiyaca binaen istediğiniz noktaya geri dönüş sağlayabilirsiniz.
- Migration'lara mümkün mertebe dokunmamak lazım. Lakin ileride ihtiyaç doğrultusunda ham SQL cümlecikleri ekleyeceğimiz ve hatta Stored Procedure gibi yapılan oluşturacağımız noktalar olacaktır.
</aside>

# Entity Framework Core Ders #9 - En Temel Entity Kuralları | OnConfiguring Fonksiyonu | Tablo Adı Belirleme 

<aside>
📌 **Temel Entity Kuralları**

</aside>

https://youtu.be/PMbJD2ZfsNQ?list=PLQVXoXFVVtp1o3nq3-IXv42bPaFlzroBE

```csharp
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
```

# Entity Framework Core Ders #10 - Veri Kalıcılığı | EF Core İle Veri Ekleme Detayları

<aside>
📌 Veri  Kalıcılığı- Veri Ekleme

</aside>

https://youtu.be/7ZTNY3traR4?list=PLQVXoXFVVtp1o3nq3-IXv42bPaFlzroBE

```csharp
using Microsoft.EntityFrameworkCore;

namespace Lesson10
{
    internal class Program
    {
        static async void Main(string[] args)
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
```

# **Entity Framework Core Ders #11 - Veri Kalıcılığı | EF Core İle Veri Güncelleme

https://youtu.be/sBRYQaYzFW8?list=PLQVXoXFVVtp1o3nq3-IXv42bPaFlzroBE

```csharp
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
```

# Entity Framework Core Ders #12 - Veri Kalıcılığı | EF Core ile Veri Güncelleme

https://youtu.be/38dUJCtPcyU?list=PLQVXoXFVVtp1o3nq3-IXv42bPaFlzroBE

```csharp
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
```


# Entity Framework Core Ders  13-14-15-16-17-18
#13 Temel Düzeyde Sorgulama Yapılanmaları  
#14 (ToListAsync, Where. OrderBy, ThenBy, OrderByDescending, ThenByDescending)   
#15 (Single, SingleOrDefault, Last, LastOrDefault, Find)   
#16(Count, LongCount, Any, Max, Min, Distinct, All, Sum, Average, Like Query )   
#17 ( ToDictionary, ToArray, Select, SelectMany)   
#18 (GroupBy Fonksiyonu ve ekstra Foreach Fonksiyonu ile pratik)  


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


# Entity Framework Core Ders 19

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
             -Change Tracker mekanizması tarafından izlenen her entity nesnesinin bilgisini EntityEntry türümden
             
             */
            #endregion

            #region AccepAllChanges Metodu
            #endregion

            #region HasChanges Metodu
            #endregion
            #endregion

            #region
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
