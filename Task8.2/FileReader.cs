namespace Task8._2
{
    public static class FileReader
    {
        public static List<string> Read(string fileName)
        {
            List<string> list = new();
            try
            {
                using (var stream = new StreamReader($@"{fileName}"))
                {
                    string? line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"{fileName} can not be found", ex.Message);
            }

            return list;
        }
    }
}