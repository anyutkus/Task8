using Task8._0;

namespace Task8._1
{
    [TrackingEntity]
    public struct Weather
    {
        [TrackingProperty]
        public string City { get; set; }

        [TrackingProperty(PropertyName = "Additional information")]
        public string Description { get; set; }

        [TrackingProperty]
        private double Temperature { get; set; }

        [TrackingProperty]
        private readonly int k = 10;

        public Weather(string city, string description, double temperature)
        {
            City = city;
            Description = description;
            Temperature = temperature;
        }
    }
}

