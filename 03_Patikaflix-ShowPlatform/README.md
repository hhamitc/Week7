

# Patikaflix Diziler Platformu - Pratik

### Patika+ BackEnd Web Geliştirme Eğitimi 7.Hafta

Bu pratikte, bir `Diziler` listesi oluşturup, elemanları kullanıcı girişiyle tanımlamanız bekleniyor. Kullanıcı her dizi eklemesinden sonra yeni bir dizi eklemek isteyip istemediği sorulacak.

## Amaç
- Konsol ekranı üzerinden dizi bilgilerini kullanıcıdan almak
- `Series` nesnelerini bir listeye eklemek
- Girilen `Komedi` türündeki dizilerden yeni bir liste oluşturmak ve belirli bilgileri (Dizi Adı, Türü, Yönetmen) içeren bir liste olarak yazdırmak
- Bu listeyi dizi isimleri ve yönetmen isimleri baz alınarak sıralamak

---

## Kullanılan Kodlar

```csharp
using _03_Patikaflix_ShowPlatform;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Series> seriesList = new List<Series>();
        bool keepAdd = true;

        do
        {
            Series serie = new Series();

            Console.Clear();
            Console.WriteLine("--------Eklenecek Dizi Bilgileri--------\n\n");

            Console.Write("Dizinin adını girin: ");
            serie.Name = Console.ReadLine();

            Console.Write("\nYapım Yılını Girin: ");
        ReTryYear:
            try
            {
                serie.Year = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Hata! Lütfen geçerli bir yıl girin: ");
                goto ReTryYear;
            }

            Console.Write("\nTürünü Giriniz: ");
            serie.Genre = Console.ReadLine();

        ReTryReleaseYear:
            try
            {
                Console.Write("\nYayına Başlama Yılını Girin: ");
                serie.ReleaseYear = Convert.ToInt32(Console.ReadLine());

                if (serie.ReleaseYear < serie.Year)
                {
                    Console.WriteLine("Yayın tarihi yapım yılından önce olamaz!");
                    goto ReTryReleaseYear;
                }
            }
            catch
            {
                Console.WriteLine("Hatalı Giriş!!");
                goto ReTryReleaseYear;
            }

            Console.Write("\nYönetmen Bilgisini Girin: ");
            serie.Director = Console.ReadLine();

            Console.Write("\nYayınlandığı ilk platfomu Girin: ");
            serie.FirstReleasePlatform = Console.ReadLine();
            Console.WriteLine("----------------------------------------------");

            seriesList.Add(serie);
            Console.WriteLine("---------------------");
            Console.WriteLine("\nBaşarıyla Eklendi.");
            Console.WriteLine("---------------------");

            Console.WriteLine();
            Console.WriteLine("Yeni bir dizi eklemek için E , eklemeyi bitirip devam etmek için H'ye basın: ");

        KeyInfo:
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
            if (keyInfo.Key == ConsoleKey.E)
            {
                continue;
            }
            else if (keyInfo.Key == ConsoleKey.H)
            {
                keepAdd = false;
            }
            else
            {
                goto KeyInfo;
            }
        } while (keepAdd);

        Console.Clear();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("                 Tüm Liste");
        Console.WriteLine("----------------------------------------------");

        foreach (var s in seriesList)
        {
            Console.WriteLine($"Adı: {s.Name}, Yılı: {s.Year} Türü: {s.Genre}, Yayın Yılı: {s.ReleaseYear} Yönetmen: {s.Director}, Platform: {s.FirstReleasePlatform} ");
        }

        var comedySeries = seriesList.Where(s => s.Genre.Contains("Komedi"))
                                     .Select(s => (s.Name, s.Genre, s.Director))
                                     .OrderBy(s => s.Name)
                                     .ThenBy(s => s.Director)
                                     .ToList();

        // Alternatif sorgu yöntemi
        // var comedySeries2 = (from s in seriesList
        //                     where s.Genre.Contains("Komedi")
        //                     orderby s.Director ascending
        //                     orderby s.Name ascending
        //                     select (s.Name, s.Genre, s.Director)).ToList();

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("             Komedi Yeni Liste");
        Console.WriteLine("----------------------------------------------");

        foreach (var series in comedySeries)
        {
            Console.WriteLine($"Adı: {series.Name}, Türü: {series.Genre}, Yönetmen: {series.Director} ");
        }

        Console.ReadKey();
    }
}
```

---

## Açıklama

- **Dizi Ekleme**: Kullanıcı, her dizi için bilgileri konsol ekranından girecektir (Ad, Yapım Yılı, Tür, Yönetmen, Yayınlandığı Platform vb.).
- **Komedi Dizileri Listesi**: `Komedi` türündeki diziler, yalnızca belirli özelliklerini (Ad, Tür, Yönetmen) içerecek şekilde filtrelenip sıralı bir listeye aktarılacaktır.
- **Sıralama**: `OrderBy` ve `ThenBy` ile liste dizi adı ve yönetmen adı baz alınarak sıralanmıştır.
- **Alternatif Sorgu**: LINQ sorgu sözdizimiyle de `Komedi` türündeki diziler için bir alternatif sorgu yazılmıştır ve yorum satırında gösterilmiştir.

---
