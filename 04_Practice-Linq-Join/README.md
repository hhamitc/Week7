

# Patika+ Back-End Web Developer Eğitimi - LINQ-JOIN Ödev 4

Bu çalışma, Patika+ Back-End Web Developer Eğitimi kapsamında sunulan LINQ Ödev 4'ü içermektedir. Ödevin amacı, yazarlar ve kitaplar listeleri üzerinde sorgulamalar yaparak birleştirme işlemlerinin sonuçlarını konsola yazdırmaktır. Bu bağlamda, kütüphane yönetim sistemine benzer bir yapı oluşturulmuştur.

## Proje Yapısı

Bu proje iki temel sınıftan oluşur:
1. **Authors (Yazarlar)**
2. **Books (Kitaplar)**

Her iki sınıf için de aşağıdaki tablolar esas alınmıştır:

- **Yazarlar Tablosu (Authors)**  
  - `AuthorId (int)` - Yazarın benzersiz kimliği  
  - `Name (string)` - Yazarın adı  

- **Kitaplar Tablosu (Books)**  
  - `BookId (int)` - Kitabın benzersiz kimliği  
  - `Title (string)` - Kitabın başlığı  
  - `AuthorId (int)` - Kitabın yazarının kimliği (Yazarlar tablosundaki AuthorId ile ilişkilidir)  

## Kurulum ve Çalıştırma

Proje, bir konsol uygulaması olarak geliştirilmiştir. Proje dosyalarını yerel bir klasöre kopyalayın ve aşağıdaki adımları takip edin:

1. Proje dosyasını herhangi bir C# IDE'si (örneğin, Visual Studio) ile açın.
2. Projeyi çalıştırarak konsol üzerinde sonuçları görüntüleyin.

## Örnek Veri

Projede kullanılmak üzere örnek yazar ve kitap verileri tanımlanmıştır:

```csharp
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
```

## LINQ Sorgusu

Yazarlar ve kitapları birleştirmek için LINQ sorgusu kullanılmıştır. Bu sorgu, her kitabın başlığını ve yazarının adını içeren bir sonuç listesi oluşturur ve ekrana yazdırır.

### Kullanılan LINQ Sorgusu (Join Kullanımı)

```csharp
var uniteBookAuthor = from book in bookList
                      join author in authorList
                      on book.AuthorId equals author.AuthorId
                      select new
                      {
                          BookName = book.Title,
                          AuthorName = author.Name
                      };
```

Bu sorgu, `bookList` ve `authorList` koleksiyonlarını `AuthorId` üzerinden birleştirerek her bir kitabın başlığını ve yazarının adını içeren bir liste oluşturur. Sonuçlar aşağıdaki formatta yazdırılır:

```csharp
foreach (var item in uniteBookAuthor)
{
    Console.WriteLine($"Kitap Adı: {item.BookName}, --> Yazar Adı: {item.AuthorName}");
}
```

### Alternatif Çözüm (Yorum Satırında)

Proje dosyasında alternatif bir LINQ sorgusu da bulunmaktadır:

```csharp
//var uniteBookAuthor = authorList.Join(bookList,
//                          author => author.AuthorId,
//                          book => book.AuthorId,
//                          (author, book) => new
//                          {
//                              BookName = book.Title,
//                              AuthorName = author.Name
//                          }
//                          );
```

Bu alternatif çözüm, `Join` metodu kullanılarak yazar ve kitapların birleştirilmesini sağlar. Her iki yöntem de aynı sonucu verir; ancak yazım şekli farklıdır.

## Çıktı Örneği

```plaintext
Kitap Adı: Kar, --> Yazar Adı: Orhan Pamuk
Kitap Adı: İstanbul, --> Yazar Adı: Orhan Pamuk
Kitap Adı: On Dakika Otuz Sekiz Saniye, --> Yazar Adı: Elif Şafak
Kitap Adı: Beyoğlu Rapsodisi, --> Yazar Adı: Ahmet Ümit
Kitap Adı: İçimizdeki Şeytan, --> Yazar Adı: Sabahattin Ali
```


---
