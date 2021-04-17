namespace CoffeeMachine.Repository.Models
{
    public class Coffee : AbstractEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public double WaterPortion { get; set; }
        public double SugarPortion { get; set; }
        public double CoffeePortion { get; set; }

    }
}
