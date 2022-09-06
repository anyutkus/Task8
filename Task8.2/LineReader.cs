namespace Task8._2
{
    public static class LineReader
    {
        public static Dictionary<string, string> LineConversion(string fileName)
        {
            var list = FileReader.Read(fileName);
            var values = new Dictionary<string, string>();

            foreach (var line in list)
            {
                try
                {
                    var temp = line.Split(", ");
                    values.Add(temp[0], temp[1]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return values;
        }
    }
}

