﻿namespace Cars.Models
{
    public class Car
    {
        public Car()
        {
        }

        public Car(string description, Owner owner, CarModel carModel)
        {
            this.Description = description;
            this.Owner = owner;
            this.Model = carModel;
        }

        public int ID { get; set; }

        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; }

        public int ModelId { get; set; }

        public virtual CarModel Model { get; set; }

        public string Description { get; set; }
    }
}
