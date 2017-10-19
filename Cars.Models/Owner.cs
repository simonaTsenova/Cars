namespace Cars.Models
{
    public class Owner
    {
        public Owner()
        {
        }

        public Owner(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
