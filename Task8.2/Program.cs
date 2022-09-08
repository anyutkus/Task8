namespace Task8._2;

public class Program
{
    public static void Main()
    {
        PrintPersonDetails();
    }

    private static void PrintPersonDetails()
    {
        var data = LineReader.LineConversion("PersonData.txt");
        SimpleBinder person = SimpleBinder.GetInstance;
        var p = person.Bind<Person>(data);
        Console.WriteLine(p?.ToString());
    }
}