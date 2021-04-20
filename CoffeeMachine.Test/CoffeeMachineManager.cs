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
        private static Order order;
        private static User user;
        private static Coffee coffee;
        private static int sum = 0;

        public static void SelectUser()
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

            Console.WriteLine($"{user.Name}, {order.User.Name}, {order.UserId}");
        }

        public static bool InsertCoins()
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

            if(user.Balance < sum)
            {
                Console.WriteLine("You don't have enough money in your balance");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void SelectCoffee()
        {
            Console.Write("Please, insert coffe id: ");
            string a;
            int id;

            do
            {
                a = Console.ReadLine();

                if(a == "")
                {

                }

                int.TryParse(a, out id);

                if (id == 0 || coffeeRepo.GetById(id) == null)
                {
                    Console.Write("Please, insert correct id: ");
                }
                else if(sum > coffeeRepo.GetById(id).Price)
                {
                    Console.Write("You didn't insert enough money for this coffee, please choose another coffee or type \"enter\" to restart inserting money: ");
                }
            } while (id == 0 || coffeeRepo.GetById(id) == null || sum > coffeeRepo.GetById(id).Price);

            coffee = coffeeRepo.GetById(id);
            order.Coffee = coffee;
            order.CoffeeId = coffee.Id;
        }

        private static bool CheckIngredients(string name)
        {
            switch (name)
            {
                case "Sugar":
                    if(coffee.SugarPortion <= ingredientRepo.GetByName(name).Quantity)
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
    }
}
