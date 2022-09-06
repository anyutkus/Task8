using Task8._0;

namespace Task8._1
{
    [TrackingEntity]
    public class Book
    {
        [TrackingProperty(PropertyName = "Author")]
        public string Author { get; set; }

        [TrackingProperty]
        public string Title { get; set; }

        public DateTime DateOfPublication { get; set; }

        public Book(string author, string title, DateTime date)
        {
            Author = author;
            Title = title;
            DateOfPublication = date;
        }
    }
}

