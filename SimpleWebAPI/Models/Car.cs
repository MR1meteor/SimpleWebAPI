namespace SimpleWebAPI.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string GearboxType { get; set; } = string.Empty;
        public string Drivetrain { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Price { get; set; }
    }
}
