namespace CoffeeMachine.Repository.Models
{
    public class Ingredient : AbstractEntity
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
    }
}
