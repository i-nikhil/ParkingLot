namespace Parking_Lot.Model
{
    public class Car
    {
        public string RegistrationNumber { get; private set; }
        public string Color { get; private set; }

        public Car( string registrationNumber, string color)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
        }
    }
}
