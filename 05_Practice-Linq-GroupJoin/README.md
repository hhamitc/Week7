# Patika+ Back-End Web Developer Eğitimi - LINQ-Group-Join Ödev 4

Bu çalışma, Patika+ Back-End Web Developer Eğitimi kapsamında sunulan LINQ Ödev 5'i içermektedir ve `LINQ GroupJoin` işlemini uygulamak için bir örnek üzerinde durmaktadır. 

## Proje Açıklaması

Bu uygulamada bir okul veritabanı oluşturulmuş ve `Students` (Öğrenciler) ile `Classes` (Sınıflar) tablosu arasındaki ilişkiyi göstermek için `GroupJoin` kullanılmıştır. Amaç, her sınıfa ait öğrencilerin listelendiği bir yapıyı oluşturmak ve sonuçları ekran çıktısı olarak sunmaktır.

## Tablo Tanımları

### Students Tablosu

- **StudentId**: Öğrencinin benzersiz kimliği (integer)
- **StudentName**: Öğrencinin adı (string)
- **ClassId**: Öğrencinin ait olduğu sınıfın kimliği (integer)

### Classes Tablosu

- **ClassId**: Sınıfın benzersiz kimliği (integer)
- **ClassName**: Sınıfın adı (string)

## Uygulama Adımları

### 1. Sınıf Tanımları
Öncelikle `Students` ve `Classes` isimli iki C# sınıfı oluşturulmuştur. Her bir sınıf, ilgili verilerin temsil edilmesini sağlar:

```csharp
public class Students
{
    public int StuudentId { get; set; }
    public string StudentName { get; set; }
    public int ClassId { get; set; }
}

public class Classes
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
}
```

### 2. Veri Listeleri
Öğrenci ve sınıf verileri örnek olarak aşağıdaki gibi bir listeye eklenmiştir:

```csharp
List<Students> studentList = new List<Students>()
{
    new Students{StuudentId = 1 , StudentName = "Ali" , ClassId = 1},
    new Students{StuudentId = 2 , StudentName = "Ayşe" , ClassId = 2},
    new Students{StuudentId = 3 , StudentName = "Mehmet" , ClassId = 1},
    new Students{StuudentId = 4 , StudentName = "Fatma" , ClassId = 3},
    new Students{StuudentId = 5 , StudentName = "Ahmet" , ClassId = 2}
};

List<Classes> classList = new List<Classes>()
{
    new Classes{ClassId = 1, ClassName = "Matematik" },
    new Classes{ClassId = 2, ClassName = "Türkçe" },
    new Classes{ClassId = 3, ClassName = "Kimya" }
};
```

### 3. LINQ GroupJoin Sorgusu
LINQ kullanarak `GroupJoin` işlemi gerçekleştirilmiş ve her sınıf altında öğrencilerin listelenmesi sağlanmıştır:

#### Method Syntax (Alternatif Yorumlanan Kod)
```csharp
var studentAndClasses = classList.GroupJoin(
    studentList,
    classItem => classItem.ClassId,
    student => student.ClassId,
    (classItem, studentClasses) => new
    {
        ClassName = classItem.ClassName,
        Student = studentClasses
    });
```

#### Query Syntax (Kullanılan Kod)
```csharp
var studentAndClasses = from classItem in classList
                        join student in studentList
                        on classItem.ClassId equals student.ClassId into studentClasses
                        select new
                        {
                            ClassName = classItem.ClassName,
                            Student = studentClasses
                        };
```

### 4. Sonuçların Yazdırılması
Sorgu sonucu elde edilen veriler aşağıdaki gibi ekrana yazdırılmıştır:

```csharp
foreach (var student in studentAndClasses)
{
    Console.WriteLine($"-----------------\nSınıf: {student.ClassName}\n------------------");
    foreach (var item in student.Student)
    {
        Console.WriteLine($"Öğrenci Adı: {item.StudentName} ");
    }
}
```

## Çıktı

```
-----------------
Sınıf: Matematik
------------------
Öğrenci Adı: Ali 
Öğrenci Adı: Mehmet 
-----------------
Sınıf: Türkçe
------------------
Öğrenci Adı: Ayşe 
Öğrenci Adı: Ahmet 
-----------------
Sınıf: Kimya
------------------
Öğrenci Adı: Fatma 
```

---

Bu `README.md` dosyası, proje adımlarını detaylı bir şekilde açıklamak için tasarlanmıştır. Kendi geliştirmelerinizde veya ödevlerinizde kullanabilirsiniz.