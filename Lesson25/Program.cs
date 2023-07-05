
using Microsoft.EntityFrameworkCore;

AppLicationDbContext context = new();

#region One to One İlişkisel Senaryolarda Veri Ekleme

#region  1. Yöntem --> Principal Entity Üzerinden Dependent Entity Verisi Ekleme
//Person person = new Person();
//person.Name = "Furkan";
//person.Address = new() { PersonAddress = "GüneşMahallesi/Antalya" };

//await context.AddAsync(person); 
//await context.SaveChangesAsync();

#endregion

//Eğer ki principal entity üzerinden ekleme gerçekleştiriliyorsa dependent entity nesnesi
//verilmek zorunda değildir! Amma velakin, dependent entity üzerinden ekleme işlemi
//gerçekleştiriliyorsa eğer burada principal entitynin nesnesine ihtiyacımız zaruridir.
#region  2. Yöntem --> Dependent Entity Üzerinden Principal Entity Verisi Ekleme

//Address address = new()
//{
//    PersonAddress = "Zeytin köy/ Antalya",
//Person = new() { Name = "Hasan"}
//};

//await context.AddAsync(address);
//await context.SaveChangesAsync();

#endregion

/*
class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }


            public Address Address { get; set; }
        }

        class Address
        {
            public int Id { get; set; }
            public string PersonAddress { get; set; }
            public Person Person { get; set; }
        }


class AppLicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Yazarlar { get; set; }
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
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Person)
            .WithOne(p => p.Address)
            .HasForeignKey<Address>(a => a.Id);

    }



}
*/
#endregion

#region One to Many İlişkisel Senaryolarda Veri Ekleme

#region  1. Yöntem --> Principal Entity Üzerinden Dependent Entity Verisi Ekleme
#region Nesne Referansı Üzerinden Ekleme
// Blog blog = new() { Name = "Furkan7asan" };
//blog.Posts.Add(new() { Title = "Post 1" });
//blog.Posts.Add(new() { Title = "Post 2" });
//blog.Posts.Add(new() { Title = "Post 3" });

//await context.AddAsync(blog);
//await context.SaveChangesAsync();
#endregion

#region Object Initializer Üzerinden Ekleme
//Blog blog2 = new()
//{
//    Name = "A Blog",
//    Posts = new HashSet<Post>() { new() {Title ="Post 4" }, new() { Title = "Post 5"} }
//};
//await context.AddAsync(blog2);
//await context.SaveChangesAsync();
#endregion

#endregion
#region  2. Yöntem --> Dependet Entity Üzerinden Principal Entity Verisi Ekleme
//Gerekmedikçe bu yöntemi kullanmayın 1. yöntem daha verimli

//Post post = new()
//{
//    Title = "Post 6",
//    Blog = new() { Name = "B Blog"}
//};
//await context.AddAsync(post);
//await context.SaveChangesAsync();
#endregion
#region  3. Yöntem --> Foreign Key Kolonu Üzerinden Veri Ekleme

//1. ve 2. yöntemler hiç olmayan verilerin ilişkisel olarak eklenmesini sağlarken, 
//bu 3. Yontem önceden eklenmiş olan bir pricipal entity verisiyle yeni dependent 
//Entitylerin ilişkisel olarak eşleştirilmesini sağlamaktadır.

//Post post = new()
//{
//    BlogId = 1,
//    Title = "Post 7",

//};
//await context.AddAsync(post);
//await context.SaveChangesAsync();
#endregion

//class Blog
//{
//    public Blog() 
//    {
//        Posts = new HashSet<Post>(); //Nesne Referansı Üzerinden Eklemek için  koleksiyon oluşturmamız gerekiyor.
//        //Object Initializer için metot içinde  koleksiyon oluşturmaya gerek yok  
//    }
//    public int Id { get; set; }
//    public string Name { get; set; }


//    public ICollection<Post> Posts { get; set; }
//}

//class Post
//{
//    public int Id { get; set; }
//    public int BlogId { get; set; } //Foreign Key Kolonu
//    public string Title { get; set; }
//    public Blog Blog { get; set; }
//}


//class AppLicationDbContext : DbContext
//{

//    public DbSet<Post> Posts { get; set; }
//    public DbSet<Blog> Blogs { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        // Provider
//        //ConnectionString
//        //Lazy Loading
//        //vb. amaçlar için kullanır.

//        optionsBuilder.UseSqlServer("Server= localhost,1433;Database=ECommerceDb;User Id sa;Passoword =1q2w3e4r+!");

//    }
//}
#endregion

#region Many to Many İlişkisel Senaryolarda Veri Ekleme
#region 1.Yöntem
// n t n ilişkisi eğer ki default convention üzerinden tasarlanmışsa kullanılan bir yöntemdir.

//Book book = new()
//{
//    BookName = "A kitap",
//    Authors = new HashSet<Author>()
//    {
//        new(){AuthorName = "Danyal"},
//        new(){AuthorName = "Ahmet"},
//        new(){AuthorName = "Hasan"},
//    }
//};
//await context.Books.AddAsync(book);
//await context.SaveChangesAsync();
//class Book
//{
//    public Book()
//    {
//        Authors = new HashSet<Author>();

//    }
//    public int Id { get; set; }
//    public string BookName { get; set; }


//    public ICollection<Author> Authors { get; set; }
//}


//class Author
//{
//    public Author()
//    {
//        Books = new HashSet<Book>();

//    }
//    public int Id { get; set; }
//    public string AuthorName { get; set; }
//    public ICollection<Book> Books { get; set; }
//}
#endregion
#region 2.Yöntem
//n t n ilişkisi eğer ki fluent API ile tasarlanmışsa kullanılan bir yöntemdir.

Author author = new()
{
    AuthorName ="Berkay",
    Books = new HashSet<BookAuthor>()
    {
        new(){BookId =1},
        new(){Book =new(){ BookName = "B Kitap"} }
    }
    };
class Book
{
    public Book()
    {
        Authors = new HashSet<BookAuthor>();

    }
    public int Id { get; set; }
    public string BookName { get; set; }


    public ICollection<BookAuthor> Authors { get; set; }
}

class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; } //Foreign Key Kolonu

    public Book Book { get; set; }
    public Author Author { get; set; }
}
class Author
{
    public Author()
    {
        Books = new HashSet<BookAuthor>();

    }
    public int Id { get; set; }
    public string AuthorName { get; set; }
    public ICollection<BookAuthor> Books { get; set; }
}
#endregion



class AppLicationDbContext : DbContext
{

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Provider
        //ConnectionString
        //Lazy Loading
        //vb. amaçlar için kullanır.

        optionsBuilder.UseSqlServer("Server= localhost,1433;Database=ECommerceDb;User Id sa;Passoword =1q2w3e4r+!");

    }

    //Fluent API için kullanılıyor.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
                    .HasKey(ba => new { ba.AuthorId, ba.BookId });

        modelBuilder.Entity<BookAuthor>()
                    .HasOne(ba => ba.Book)
                    .WithMany(b => b.Authors)
                    .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<BookAuthor>()
                    .HasOne(ba => ba.Book)
                    .WithMany(b => b.Books)
                    .HasForeignKey(ba => ba.AurthorId);
    }
}
#endregion

