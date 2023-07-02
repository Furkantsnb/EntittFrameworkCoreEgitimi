using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Lesson21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }



        #region Relationships(ilişkiler) Terimleri

        #region Principal Entity(Asıl Entity)
        //Kendi başına var olabilen tabloyu modelleyen entity'e denir.

        //Departmanlar tablosunu modelleyen 'Departman' Entity'sidir.
        #endregion

        #region Dependent Entity(Bağımlı Entity)
        //Kendi başına var olmayan, bir başka tabloya bağımlı(ilişkisel olarak bağımlı)
        //olan tanloyu modelleyen entity'e denir.

        //Calısanlar tablosu modelleyen 'Calısan' entity'sidir.

        #endregion

        #region Foreign Key
        // Principal Entity ile Dependent Entity arasındaki ilişkiyi sağlayan key'dir.

        //Dependent Entity' de tanımlanır.

        // Principal Entity' de ki  Principal Key' i tutar. 
        #endregion

        #region Principal Key
        //Principal Entity' deki İd'in kendisidir. Principal Entity'nin kimliği olan
        //kolonu ifade eden propertydir.
        #endregion

        #endregion

        #region Navigation Property Nedir?
        // ilişkisel tablolar arasındaki fiziksel erişimi entity class'ları üzerinden sağlayan property'lerdir.

        //bir property' nin navigation property olabilmesi için kesinlikle entity türünde olması gerekiyor.

        //Navigation property'ler entity'lerdeki  tanımlarına göre n'e n yahut 1'e n şeklinde ilişkisel 
        //yapıları tam teferruatlı pratikte incelerken navigation property'lerin bu özelliklerinden 
        //istifade ettiğimizi göreceksiniz.
        #endregion

        #region İlişki Türleri

        #region One to One
        //Çalışan ile adresi arasındaki ilişki, 
        //Karı kocaarasında ki ilişki
        #endregion

        #region One to Many
        //Çalışan ile departman arasındaki ilişki
        //Anne ve çocukları arasındaki ilişki
        #endregion

        #region Many to Many
        //Çalışanlar ile projeler arasındaki ilişki
        //kardeşler arasındaki ilişki
        #endregion

        #endregion

        #region Entity Framwork Core' da İlişki Yapılandırma Yöntemleri

        #region Default Convetions
        //Varsayılan entity kurallarını kullanarak yapılan ilişki yapılandırma yöntemleridir.

        //Navigation property'leri kullanarak ilişki şablonlarını çıkarmaktadır.
        #endregion

        #region  Data Annotions Attributes
        // Entity'nin niteliklerine göre ince ayarlar yapmamızı sağlayan attributr'lardır. [Key],[ForeignKey] karşılık geliyor.

        #endregion

        #region Fluent API
        //Entity modellerindeki ilişkileri yapılandırırken daha detaylı çalışmamızı sağlayan yöntemdir.

        #region  HasOne
        //ilgili entity'nin ilişkisel entity'ye birebir ya da bire çok olacak şekilde ilişkinin yapılandırmaya başlayan metottur.
        #endregion

        #region HasMany
        //ilgili entity'nin ilişkisel entity'ye çoka bir ya da çoka çok olacak şekilde ilişkinin yapılandırmaya başlayan metottur.
        #endregion

        #region WithOne
        //HasOne ya da HasMany' den sonra bire bir ya da çoka bir olacak şekilde ilişki yapılandırmasını tanımlayan metotdur.
        #endregion

        #region WithMany
        //HasOne ya da HasMany' den sonra bire çok ya da çoka çok olacak şekilde ilişki yapılandırmasını tanımlayan metotdur.

        #endregion

        #endregion
        #endregion

    }
    class Calisan
    {
        public int Id { get; set; }
        public string CalisanAdi { get; set; }
        public int DepartmanId { get; set; }
        public Departman Departman { get; set; } //Navigation Property'lerimiz
    }

     class Departman
    {
        public int Id { get; set; }
        public string DepartmanAdi { get; set; } // Foreign Key karşılık geliyor.

        public ICollection<Calisan> Calisanlar { get; set; }//Navigation Property'lerimiz
    }
 }

 
   
