namespace CoffeeMachine.Repository.Models
{
    public class User : AbstractEntity
    {
        public string Name { get; set; }
        public int Balance { get; set; }
    }
}
