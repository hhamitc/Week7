
# Patika+ Back-End Web Developer Eğitimi - LINQ Ödev 2

Bu çalışma, Patika+ Back-End Web Developer Eğitimi kapsamında sunulan LINQ Ödev 2'yi içermektedir. Ödevde verilen bir şarkıcı listesi üzerinde farklı sorgulamalar yaparak sonuçları konsola yazdıran bir uygulama geliştirilmiştir.

## Proje Açıklaması

Bu projede, 11 sanatçıdan oluşan bir liste üzerinde çeşitli LINQ sorguları gerçekleştirilmiştir. Her bir sorgunun amacı belirli filtreleme ve sıralama işlemlerini yerine getirmektir. Çözümde sorgular, LINQ metotları ve sorgu ifadeleri kullanılarak yazılmıştır.

## Kullanılan Veri Yapısı

```csharp
public class Singer
{
    public string SingerNameSurname { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public int AlbumSales { get; set; }
}
```

## Sorgular ve Çözümler

### 1. Adı 'S' ile Başlayan Şarkıcılar
#### Sorgu Tipi ile Çözüm
```csharp
var NameStartsWithS = from singer in singers
                      where singer.SingerNameSurname.StartsWith("S")
                      select singer;
```
#### Metot Zinciri (Alternatif Çözüm)
```csharp
// var NameStartsWithS = singers.Where(s => s.SingerNameSurname.StartsWith("S"));
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("{0,-25}: ", "Adı S ile Başlayanlar");
Console.WriteLine(new string('-', 33));
foreach (var item in NameStartsWithS)
{
    Console.WriteLine("{0, -20}: ", string.Join(", ", item.SingerNameSurname, item.Genre, item.ReleaseYear, item.AlbumSales));
}
Console.WriteLine(new string('-', 33));
```

### 2. Albüm Satışları 10 Milyon'un Üzerinde Olan Şarkıcılar
#### Sorgu Tipi ile Çözüm
```csharp
var Over10MSales = from singer in singers
                   where singer.AlbumSales > 10000000
                   select singer;
```
#### Metot Zinciri (Alternatif Çözüm)
```csharp
// var Over10MSales = singers.Where(s => s.AlbumSales > 10000000);
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("{0,-25}: ", "10 M Üzeri Satanlar");
Console.WriteLine(new string('-', 33));
foreach (var item in Over10MSales)
{
    Console.WriteLine("{0, -20}: ", string.Join(", ", item.SingerNameSurname, item.Genre, item.ReleaseYear, item.AlbumSales));
}
Console.WriteLine(new string('-', 33));
```

### 3. 2000 Yılı Öncesi Çıkış Yapmış ve Pop Müzik Yapan Şarkıcılar
#### Sorgu Tipi ile Çözüm
```csharp
// var Before2000Pop = from singer in singers
//                     where singer.ReleaseYear < 2000 && singer.Genre.Contains("Pop")
//                     orderby singer.SingerNameSurname ascending
//                     group singer by singer.ReleaseYear into groupedByYear
//                     orderby groupedByYear.Key
//                     select groupedByYear;
```
#### Metot Zinciri Çözümü
```csharp
var Before2000Pop = singers.Where(s => s.ReleaseYear < 2000 && s.Genre.Contains("Pop"))
                           .OrderBy(s => s.SingerNameSurname)
                           .GroupBy(s => s.ReleaseYear)
                           .OrderBy(g => g.Key);
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("2000 Öncesi Yıla Göre Gruplu - Sıralı");
Console.WriteLine(new string('-', 33));
foreach (var group in Before2000Pop)
{
    Console.WriteLine($"Çıkış Yılı: {group.Key}");
    foreach (var singer in group)
    {
        Console.WriteLine($"- {singer.SingerNameSurname}, {singer.Genre}, {singer.ReleaseYear}, {singer.AlbumSales}");
    }
    Console.WriteLine(new string('-', 33));
}
```

### 4. En Çok Albüm Satan Şarkıcı
#### Sorgu Tipi ile Çözüm
```csharp
var BestSellerSinger = (from singer in singers
                        orderby singer.AlbumSales descending
                        select singer).First();
```
#### Metot Zinciri (Alternatif Çözüm)
```csharp
// var BestSellerSinger = singers.OrderByDescending(s => s.AlbumSales).First();
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("En Çok Albüm Satan:");
Console.WriteLine($"Adı: {BestSellerSinger.SingerNameSurname}, \nSatış Adedi: {BestSellerSinger.AlbumSales}");
Console.WriteLine(new string('-', 33));
```

### 5. En Yeni ve En Eski Çıkış Yapan Şarkıcılar
#### En Yeni Çıkış Yapan Şarkıcı (Sorgu Tipi)
```csharp
var LatestReleaseSinger = (from singer in singers
                           orderby singer.ReleaseYear descending
                           select singer).First();
```
#### Metot Zinciri (Alternatif Çözüm)
```csharp
// var LatestReleaseSinger = singers.OrderByDescending(s => s.ReleaseYear).First();
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("En Yeni Çıkış Yapan:");
Console.WriteLine($"Adı: {LatestReleaseSinger.SingerNameSurname}, \nÇıkış Yılı: {LatestReleaseSinger.ReleaseYear}");
Console.WriteLine(new string('-', 33));
```

#### En Eski Çıkış Yapan Şarkıcı (Sorgu Tipi)
```csharp
var OldestReleaseSinger = (from singer in singers
                           orderby singer.ReleaseYear ascending
                           select singer).First();
```
#### Metot Zinciri (Alternatif Çözüm)
```csharp
// var OldestReleaseSinger = singers.OrderBy(s => s.ReleaseYear).First();
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("En Eski Çıkış Yapan:");
Console.WriteLine($"Adı: {OldestReleaseSinger.SingerNameSurname}, \nÇıkış Yılı: {OldestReleaseSinger.ReleaseYear}");
Console.WriteLine(new string('-', 33));
```

## Sonuçlar
- **Adı 'S' ile başlayan şarkıcılar**, `SingerNameSurname` özelliğine göre filtrelenmiştir.
- **Albüm satışları 10 milyon'un üzerinde olan şarkıcılar**, `AlbumSales` kriterine göre seçilmiştir.
- **2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar**, `ReleaseYear` ve `Genre` özelliklerine göre gruplandırılmış ve alfabetik sırada yazdırılmıştır.
- **En çok albüm satan şarkıcı**, `AlbumSales` özelliğine göre sıralanarak bulunmuştur.
- **En yeni ve en eski çıkış yapan şarkıcılar**, `ReleaseYear` özelliğine göre sıralanarak belirlenmiştir.

---

