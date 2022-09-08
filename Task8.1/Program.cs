using Task8._0;

namespace Task8._1;

public class Program
{
    public static void Main()
    {
        var book = new Book("Jane Austen", "Emma", new DateTime(1815, 12, 23));
        Logger.Track<Book>("Book", book);

        var weather = new Weather("London", "Sunny spells", 19);
        Logger.Track<Weather>("Weater.json", weather);

        int i = 1;
        Logger.Track<int>("int", i);
    }
}

