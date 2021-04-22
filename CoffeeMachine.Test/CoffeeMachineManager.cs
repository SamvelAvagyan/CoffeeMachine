using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoffeeMachine.Test
{
    public static class CoffeeMachineManager
    {
        public static IUserRepository userRepo = Program.serviceProvider.GetService<IUserRepository>();
        public static ICoffeeRepository coffeeRepo = Program.serviceProvider.GetService<ICoffeeRepository>();
        public static IIngredientRepository ingredientRepo = Program.serviceProvider.GetService<IIngredientRepository>();
        public static IOrderRepository orderRepo = Program.serviceProvider.GetService<IOrderRepository>();
        private static Order order;
        private static User user;
        private static Coffee coffee;
        private static int sum = 0;

        private static void SelectUser()
        {
            Console.Write("Please, insert id of user, who wants to buy a coffee: ");
            int id;

            do
            {
                int.TryParse(Console.ReadLine(), out id);

                if (id == 0 || userRepo.GetById(id) == null)
                {
                    Console.Write("Please, insert correct id: ");
                }
            } while (id == 0 || userRepo.GetById(id) == null);

            order = new Order();
            user = userRepo.GetById(id);
            order.User = user;
            order.UserId = user.Id;
        }

        private static bool InsertCoins()
        {
            Console.Write("Please, insert coin (50, 100, 200, 500) (Type enter to finish this action): ");
            string c;
            int coin;
            bool t;

            do
            {
                c = Console.ReadLine();
                if (c == "")
                {
                    break;
                }

                int.TryParse(c, out coin);
                t = coin != 50 && coin != 100 && coin != 200 && coin != 500;

                if (coin == 0 || t)
                {
                    coin = 0;
                    Console.Write("Please, insert coins that allowed (50, 100, 200, 500) (Type enter to finish this action): ");
                }
                else
                {
                    Console.Write("Please, insert coin (50, 100, 200, 500) (Type enter to finish this action): ");
                }

                sum += coin;
            } while (true);

            if (user.Balance < sum)
            {
                Console.WriteLine("You don't have enough money in your balance");
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void SelectCoffee()
        {
            Console.Write("Please, insert coffee id: ");
            string a;
            int id;

            do
            {
                a = Console.ReadLine();

                if (a == "")
                {
                    StartFromInsertingCoins();
                }

                int.TryParse(a, out id);

                if (id == 0 || coffeeRepo.GetById(id) == null)
                {
                    Console.Write("Please, insert correct id: ");
                }
                else if (sum < coffeeRepo.GetById(id).Price)
                {
                    Console.Write("You didn't insert enough money for this coffee, please choose another coffee or type enter to restart: ");
                }
            } while (id == 0 || coffeeRepo.GetById(id) == null || sum < coffeeRepo.GetById(id).Price);

            coffee = coffeeRepo.GetById(id);

            if (CheckIngredients("Sugar") && CheckIngredients("Coffee") && CheckIngredients("Water"))
            {
                order.Coffee = coffee;
                order.CoffeeId = coffee.Id;
                ingredientRepo.GetByName("Sugar").Quantity -= coffee.SugarPortion;
                ingredientRepo.Update(ingredientRepo.GetByName("Sugar"));
                ingredientRepo.GetByName("Water").Quantity -= coffee.WaterPortion;
                ingredientRepo.Update(ingredientRepo.GetByName("Water"));
                ingredientRepo.GetByName("Coffee").Quantity -= coffee.CoffeePortion;
                ingredientRepo.Update(ingredientRepo.GetByName("Coffee"));
            }
        }

        private static bool CheckIngredients(string name)
        {
            switch (name)
            {
                case "Sugar":
                    if (coffee.SugarPortion <= ingredientRepo.GetByName(name).Quantity)
                        return true;
                    else
                        return false;

                case "Coffee":
                    if (coffee.CoffeePortion <= ingredientRepo.GetByName(name).Quantity)
                        return true;
                    else
                        return false;

                case "Water":
                    if (coffee.WaterPortion <= ingredientRepo.GetByName(name).Quantity)
                        return true;
                    else
                        return false;

                default:
                    return false;
            }
        }

        public static void Start()
        {
            SelectUser();
            if (InsertCoins())
            {
                SelectCoffee();
                Ready();
                AskToEnterZero();
            }
            else
            {
                StartFromInsertingCoins();
            }
        }

        private static void StartFromInsertingCoins()
        {
            if (InsertCoins())
            {
                SelectCoffee();
                Ready();
                AskToEnterZero();
            }
            else
            {
                StartFromInsertingCoins();
            }
        }

        private static void StartFromSelectingCoffee()
        {
            SelectCoffee();
            Ready();
            AskToEnterZero();
        }

        private static void Ready()
        {
            Console.WriteLine("Ready!");
            orderRepo.Add(order);
            user.Balance -= coffee.Price;
            userRepo.Update(user);
        }

        private static void AskToEnterZero()
        {
            Console.Write("If you want to change or choose another coffee, then enter 0, else type enter: ");
            string a;

            do
            {
                a = Console.ReadLine();

                if (a != "0" && a != "")
                {
                    Console.Write("Please, type 0 or enter: ");
                }
            } while (a != "0" && a != "");

            if (a == "0")
            {
                user.Balance += coffee.Price;
                userRepo.Update(user);
                orderRepo.Delete(order.Id);
                StartFromSelectingCoffee();
            }
            else
            {
                Console.WriteLine($"Your tip back is: {sum - coffee.Price}, Thank you!");
            }
        }

        public static void ShowUsers()
        {
            Console.WriteLine("Users");
            Console.WriteLine("==========================================================================");

            foreach (var user in userRepo.GetAll())
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Balance: {user.Balance}");
            }

            Console.WriteLine("==========================================================================");
        }

        public static void ShowCoffees()
        {
            Console.WriteLine("Coffees");
            Console.WriteLine("==========================================================================");

            foreach (var coffee in coffeeRepo.GetAll())
            {
                Console.WriteLine($"Id: {coffee.Id}, Name: {coffee.Name}, Price: {coffee.Price}, WaterPortion: {coffee.WaterPortion}" +
                    $", SugarPortion: {coffee.SugarPortion}, CoffeePortion: {coffee.CoffeePortion}");
                Console.Write("--------------------------------------------------------------------------------");
            }

            Console.WriteLine("==========================================================================");
        }
    }
}
