namespace CoffeeMachine.Repository.Models
{
    public class Order : AbstractEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CoffeeId { get; set; }
        public Coffee Coffee { get; set; }
    }
}
