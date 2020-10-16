using Task_2.Users.Roles;

namespace Task_2.Users
{
    class BaseUser : User
    {
        //?
        //public BaseUser(string name,int? age=null,int? balance=null)
        //{
        //    Name = name;
        //    Age = age ?? default;
        //    Balance = balance ?? default;
        //    Role = UserRole.Base;
        //}
        public BaseUser(string name)
        {
            Name = name;
            Role = UserRole.Base;
        }
        public BaseUser(string name, int age):this(name)
        {
            Age = age;   
        }
        public BaseUser(string name, int age, int balance) : this(name, age)
        {
            Balance = balance;
        }
        
        public override string GetInfo()
        {
            return $"Hello, my name is {Name} {(NickName==string.Empty||NickName==null?"": "aka" + NickName)}, I'm {Age} years old {Role} with {Balance} money in my pocket";
        }

        public override void DoJob()
        {
            Balance += 1;
        }
        public override User Upgrade()
        {
            return Balance > 10 ?new AdminUser(Name, Age, Balance - 10) { NickName = NickName } as User : this ;
        }
    }
}

