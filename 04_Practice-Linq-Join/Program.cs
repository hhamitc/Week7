using _04_Practice_Linq_Join;

public class Program
{
    public static void Main(string[] args)
    {
        List<Authors> authorList = new List<Authors>()
        {
            new Authors{AuthorId=1, Name = "Orhan Pamuk" },
            new Authors{AuthorId=2, Name = "Elif Şafak" },
            new Authors{AuthorId=3, Name = "Ahmet Ümit" },
            new Authors{AuthorId=4, Name = "Sabahattin Ali" }
        };

        List<Books> bookList = new List<Books>()
        {
            new Books{BookId=1, Title="Kar", AuthorId=1},
            new Books{BookId=2, Title="İstanbul", AuthorId=1},
            new Books{BookId=3, Title="On Dakika Otuz Sekiz Saniye", AuthorId=2},
            new Books{BookId=4, Title="Beyoğlu Rapsodisi", AuthorId=3},
            new Books{BookId=5, Title="İçimizdeki Şeytan", AuthorId=4}

        };

        //var uniteBookAuthor = authorList.Join(bookList,
        //                          author => author.AuthorId,
        //                          book => book.AuthorId,
        //                          (author, book) => new
        //                          {
        //                              BookName = book.Title,
        //                              AuthorName = author.Name
        //                          }
        //                          );

        var uniteBookAuthor = from book in bookList
                              join author in authorList
                              on book.AuthorId equals author.AuthorId
                              select new
                              {
                                  BookName = book.Title,
                                  AuthorName = author.Name
                              };


        foreach (var item in uniteBookAuthor)
        {
            Console.WriteLine($"Kitap Adı: {item.BookName}, --> Yazar Adı: {item.AuthorName}");
        }




        Console.ReadKey();
    }
}