namespace Shop
{
    public class Car
    {
        public int Id { get; }
        public string Model { get; }
        public Car(int id, string model)
        {
            Model = model;
            Id = id;
        }

    }
}