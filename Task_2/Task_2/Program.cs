using System;
using Task_2.UserInterface;
using Task_2.UserManagers;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI(new UserManager());

            while (true)
            {
                var line = Console.ReadLine();

                if (line.Length != 1) break;

                ui.CommandExecute(line);
            }
        }
    }
}
