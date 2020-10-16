using System;
using Task_2.Users.Roles;

namespace Task_2.Users
{
    class SecretUser : User
    {
        readonly private Random rand = new Random();

        public SecretUser(string name)
        {
            Name = name;
            Role = UserRole.Secret;
        }


        public SecretUser(string name, int age) : this(name)
        {
            Age = age;
        }

        public SecretUser(string name, int age, int balance) : this(name, age)
        {
            Balance = balance;
        }

        public override string GetInfo()
        {
            return "Info is secret";
        }

        public override void DoJob()
        {
            Balance += rand.Next(1, 5);
        }

        public override User Upgrade()
        {
            Console.WriteLine("You role is better");
            return this;
        }
    }
}
