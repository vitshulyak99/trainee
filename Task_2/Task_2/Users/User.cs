
using Task_2.Users.Roles;

namespace Task_2
{
    abstract class User
    {
        public int Balance { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public int Age { get; set; }

        public UserRole Role { get; set; }

        public abstract void DoJob();

        public abstract string GetInfo();

        public void AddToBalance(int val)
        {
            Balance = Balance + val < 0 ? 0 : Balance + val;
        }

        public abstract User Upgrade();
    }
}