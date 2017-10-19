namespace Cars.Models
{
    public class Car
    {
        public int ID { get; set; }

        public int OwnerId { get; set; }

        public Owner Owner { get; set; }

        public int ModelId { get; set; }

        public CarModel CarModel { get; set; }

        public string Description { get; set; }
    }
}
