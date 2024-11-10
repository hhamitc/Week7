internal class Program
{
    private static void Main(string[] args)
    {
        // Liste oluşturma
        List<int> numberList = new List<int>();

        //Rasthele sayı oluşturmak için Random sınıfından üretme
        Random random = new Random();


        // 10 Adet sayıyı for ile üretip Listeye ekleme.
        for (int i = 0; i < 10; i++)
        {
            int number = random.Next(-25, 26);
            numberList.Add(number);
        }
        //Üretilen listeyi yazdırma.
        Console.Write("{0,-20}: ", "Tam Liste");
        foreach (var item in numberList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n----------------------");



        //Üretilen listeden çift sayıları filtreleme 
        var EvenNumbers = numberList.Where(num => num % 2 == 0);
        //Filtrelenen sayıları yazdırma.
        Console.Write("{0,-20}: ", "Çift Sayılar");
        foreach (var item in EvenNumbers)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n----------------------");



        // ÜRetilen tek sayıları yazdırma
        var OddNumbers = numberList.Where(num => num % 2 != 0);
        //Filtrelenen sayıları yazdırma.
        Console.Write("{0,-20}: ", "Tek Sayılar");
        foreach (var item in OddNumbers)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\n----------------------");



        //Negatif Sayıları Filtreleme
        var NegativeNumbers = from number in numberList
                              where number < 0
                              select number;
        //Filtrelenen numaraları yazdırma.
        Console.Write("{0,-20}: ", "Negatif Sayılar");
        foreach (var item in NegativeNumbers)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n----------------------");



        //Pozitif Sayıları Filtreleme
        var PositiveNumbers = numberList.Where(num => num > 0);
        //Filtrelenen Sayıları Yazdırma
        Console.Write("{0,-20}: ", "Pozitif Sayılar");
        foreach (var item in PositiveNumbers)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n----------------------");



        // 15'den büyük ve 22 den küçük sayıları filtreleme
        var SelectedAreaNumbers = numberList.Where(num => num > 15 && num < 22);
        //Filtrelenen Sayıları Yazdırma
        Console.Write("{0,-20}: ", "15-22 Arasındakiler");
        foreach (var item in SelectedAreaNumbers)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n----------------------");



        //Listedeki her elemanın karesini alıp yeni liste oluşturma
        var SquaredNumbers = numberList.Select(num => num * num).ToList();

        //Yeni Listeyi yazdırma;
        Console.Write("{0,-20}: ", "Sayıların Kareleri:");
        foreach (var item in SquaredNumbers)
        {
            Console.Write($"{item} ");
        }







        Console.ReadKey();
    }
}