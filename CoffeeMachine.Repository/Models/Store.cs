﻿namespace CoffeeMachine.Repository.Models
{
    public class Store : AbstractEntity
    {
        public double Water { get; set; }
        public double Sugar { get; set; }
        public double Coffee { get; set; }
    }
}