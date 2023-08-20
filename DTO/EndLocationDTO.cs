namespace RealTimeUber.DTO
{
    public class EndLocationDTO
    {
        public DateTime Timestamp { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
