namespace Cars.Models
{
    public class CarModel
    {
        public CarModel()
        {
        }

        public CarModel(string description)
        {
            this.Description = description;
        }

        public int ID { get; set; }

        public string Description { get; set; }
    }
}
