

# Patika+ Back-End Web Developer Eğitimi - LINQ Ödev 2

Bu çalışma, Patika+ Back-End Web Developer Eğitimi kapsamında sunulan LINQ Ödev 2'yi içermektedir. Ödevde verilen bir şarkıcı listesi üzerinde farklı sorgulamalar yaparak sonuçları konsola yazdıran bir uygulama geliştirilmiştir.

## Proje Açıklaması

Bu projede, 11 sanatçıdan oluşan bir liste üzerinde çeşitli LINQ sorguları gerçekleştirilmiştir. Her bir sorgunun amacı belirli filtreleme ve sıralama işlemlerini yerine getirmektir. Çözümde sorgular, LINQ sorgu ifadeleri ve metot zinciri kullanılarak gerçekleştirilmiştir.

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

## Örnek Veri Listesi

```csharp
List<Singer> singers = new List<Singer>()
{
    new Singer { SingerNameSurname = "Ajda Pekkan", Genre = "Pop", ReleaseYear = 1968, AlbumSales = 20000000 },
    new Singer { SingerNameSurname = "Sezen Aksu", Genre = "Türk Halk Müziği / Pop", ReleaseYear = 1971, AlbumSales = 10000000 },
    new Singer { SingerNameSurname = "Funda Arar", Genre = "Pop", ReleaseYear = 1999, AlbumSales = 3000000 },
    new Singer { SingerNameSurname = "Sertab Erener", Genre = "Pop", ReleaseYear = 1994, AlbumSales = 5000000 },
    new Singer { SingerNameSurname = "Sıla", Genre = "Pop", ReleaseYear = 2009, AlbumSales = 3000000 },
    new Singer { SingerNameSurname = "Serdar Ortaç", Genre = "Pop", ReleaseYear = 1994, AlbumSales = 10000000 },
    new Singer { SingerNameSurname = "Tarkan", Genre = "Pop", ReleaseYear = 1992, AlbumSales = 40000000 },
    new Singer { SingerNameSurname = "Hande Yener", Genre = "Pop", ReleaseYear = 1999, AlbumSales = 7000000 },
    new Singer { SingerNameSurname = "Hadise", Genre = "Pop", ReleaseYear = 2005, AlbumSales = 5000000 },
    new Singer { SingerNameSurname = "Gülben Ergen", Genre = "Pop / Türk Halk Müziği", ReleaseYear = 1997, AlbumSales = 10000000 },
    new Singer { SingerNameSurname = "Neşet Ertaş", Genre = "Türk Halk Müziği / Türk Sanat Müziği", ReleaseYear = 1960, AlbumSales = 2000000 }
};
```

## Sorgular ve Çözümler

### 1. Adı 'S' ile Başlayan Şarkıcılar
#### Sorgu Tipi ile Çözüm
```csharp
var nameStartsWithS = from singer in singers
                      where singer.SingerNameSurname.StartsWith("S")
                      select singer;
```
#### Metot Zinciri (Alternatif Çözüm)
```csharp
// var nameStartsWithS = singers.Where(s => s.SingerNameSurname.StartsWith("S"));
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("{0,-25}: ", "Adı S ile başlayanlar");
Console.WriteLine(new string('-', 33));
foreach (var item in nameStartsWithS)
{
    Console.WriteLine("{0, -20}: ", string.Join(", ", item.SingerNameSurname, item.Genre, item.ReleaseYear, item.AlbumSales));
}
Console.WriteLine(new string('-', 33));
```

### 2. Albüm Satışları 10 Milyon'un Üzerinde Olan Şarkıcılar
#### Sorgu Tipi ile Çözüm
```csharp
var over10MSales = from singer in singers
                   where singer.AlbumSales > 10000000
                   select singer;
```
#### Metot Zinciri (Alternatif Çözüm)
```csharp
// var over10MSales = singers.Where(s => s.AlbumSales > 10000000);
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("{0,-25}: ", "10 M Üzeri Satanlar");
Console.WriteLine(new string('-', 33));
foreach (var item in over10MSales)
{
    Console.WriteLine("{0, -20}: ", string.Join(", ", item.SingerNameSurname, item.Genre, item.ReleaseYear, item.AlbumSales));
}
Console.WriteLine(new string('-', 33));
```

### 3. 2000 Yılı Öncesi Çıkış Yapmış ve Pop Müzik Yapan Şarkıcılar
#### Metot Zinciri Çözümü
```csharp
var before2000Pop = singers.Where(s => s.ReleaseYear < 2000 && s.Genre.Contains("Pop"))
                           .OrderBy(s => s.SingerNameSurname)
                           .GroupBy(s => s.ReleaseYear)
                           .OrderBy(g => g.Key);
```
#### Konsola Yazdırma
```csharp
Console.WriteLine("2000 Öncesi Yıla Göre Gruplu - Sıralı");
Console.WriteLine(new string('-', 33));
foreach (var group in before2000Pop)
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
var bestSellerSinger = (from singer in singers
                        orderby singer.AlbumSales descending
                        select singer).First();
```
#### Metot Zinciri (Alternatif Çözüm)
```csharp
// var bestSellerSinger = singers.OrderByDescending(s => s.AlbumSales).First();
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("En çok albüm satan:");
Console.WriteLine($"Adı: {bestSellerSinger.SingerNameSurname}, \nSatış Adedi: {bestSellerSinger.AlbumSales}");
Console.WriteLine(new string('-', 33));
```

### 5. En Yeni ve En Eski Çıkış Yapan Şarkıcılar
#### En Yeni Çıkış Yapan Şarkıcı (Sorgu Tipi)
```csharp
var latestReleseSinger = (from singer in singers
                          orderby singer.ReleaseYear descending
                          select singer).First();
```
#### Metot Zinciri (Alternatif Çözüm)
```csharp
// var latestReleseSinger = singers.OrderByDescending(s => s.ReleaseYear).First();
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("En yeni çıkış yapan:");
Console.WriteLine($"Adı: {latestReleseSinger.SingerNameSurname}, \nÇıkış Yılı: {latestReleseSinger.ReleaseYear}");
Console.WriteLine(new string('-', 33));
```

#### En Eski Çıkış Yapan Şarkıcı (Metot Zinciri)
```csharp
var oldestReleseSinger = singers.OrderBy(s => s.ReleaseYear).First();
```
#### Sorgu Tipi (Alternatif Çözüm)
```csharp
// var oldestReleseSinger = (from singer in singers
//                          orderby singer.ReleaseYear
//                          select singer).First();
```

#### Konsola Yazdırma
```csharp
Console.WriteLine("En Eski çıkış yapan:");
Console.WriteLine($"Adı: {oldestReleseSinger.SingerNameSurname}, \nÇıkış Yılı: {oldestReleseSinger.ReleaseYear}");
Console.WriteLine(new string('-', 33));
```

---
