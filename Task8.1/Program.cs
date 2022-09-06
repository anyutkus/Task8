using Task8._0;

namespace Task8._1;

public class Program
{
    public static void Main()
    {
        var book = new Book("Jane Austen", "Emma", new DateTime(1815, 12, 23));
        var check1 = new Logger<Book>("Book", book);

        var weather = new Weather("London", "Sunny spells", 19);
        var check2 = new Logger<Weather>("Weater.json", weather);

        int i = 1;
        var check3 = new Logger<int>("int", i);
    }
}

