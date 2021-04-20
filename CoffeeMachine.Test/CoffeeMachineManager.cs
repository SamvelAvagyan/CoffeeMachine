using System;

namespace CoffeeMachine.Test
{
    public static class CoffeeMachineManager
    {
        public static void SelectUser()
        {
            Console.Write("Please, insert id of user, who wants to buy a coffee: ");
            int id;

            do
            {
                int.TryParse(Console.ReadLine(), out id);

                if(id == 0)
                {
                    Console.Write("Please, insert correct id: ");
                }
            } while (id == 0);      
        }

        public static void InsertCoins()
        {

        }
    }
}
