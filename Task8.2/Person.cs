namespace Task8._2
{
    public class Person
    {
        public Person()
        {
        }

        public int number;
        public string? Author { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return number.ToString() + "\n" + Author + "\n" + Age.ToString() + "\n" + Salary.ToString() + "\n";
        }
    }
}

