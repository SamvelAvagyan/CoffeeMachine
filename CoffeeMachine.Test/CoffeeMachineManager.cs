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
        private static Order order;
        private static User user;

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

        public static void InsertCoins()
        {
            Console.Write("Please, insert coin (50, 100, 200, 500) (Type enter to finish this action): ");
            string c;
            int coin;
            int sum = 0;
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

            Console.WriteLine(sum);
        }
    }
}
