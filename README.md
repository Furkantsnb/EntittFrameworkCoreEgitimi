# Entity Framework Core Egitimi
ORM yaklaşımı ile Entity Framework Core eğitimini görerek hazırladığım notlar için öncelikle " Gençay Yıldız " Hocamıza  
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
