using Task_2.Users.Roles;

namespace Task_2.Users
{
    class AdminUser : User
    {
        //почему бы не сделать так?
        //public AdminUser(string name, int? age = null, int? balance = null)
        //{
        //    Name = name;
        //    Age = age ?? default;
        //    Balance = balance ?? default;
        //    Role = UserRole.Admin;
        //}

        public AdminUser(string name)
        {
            Name = name;
            Role = UserRole.Admin;
        }

        public AdminUser(string name, int age) : this(name)
        {
            Age = age;
        }

        public AdminUser(string name, int age, int balance) : this(name, age)
        {
            Balance = balance;
        }
        public override string GetInfo()
        {
            return string.Format(@"Hello, my name is {0}, I'm {1} years old {2} {3}", Name, Age, Role, Balance < 10 ? "" : $"with {Balance} in my Bitcoin Wallet");
        }

        public override void DoJob()
        {
            Balance += 2;
        }

        public override User Upgrade()
        {
            return Balance > 20 ? new SecretUser(Name, Age, 0) { NickName = NickName } as User : this;
        }
    }
}
