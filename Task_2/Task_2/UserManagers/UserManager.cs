using System.Collections.Generic;
using Task_2.Users;

namespace Task_2.UserManagers
{
    class UserManager
    {
        readonly private List<User> _primary;

        public List<User> Users { get; }

        public UserManager()
        {
            _primary = new List<User>();
            Users = new List<User>();
            _primary.Add(new BaseUser("Jhon Snow", 23, 10) { NickName = "Snowy" });
            _primary.Add(new AdminUser("Admin Adminovich", 25, 12));
            _primary.Add(new BaseUser("Richi Den", 30, 1));
            _primary.Add(new AdminUser("Vasya Vasin", 40, 2));
            _primary.Add(new SecretUser("Anonymous", 23, 26));
            SetDefaultList();
        }

        public void SetDefaultList()
        {
            Users.Clear();
            _primary.ForEach(p => Users.Add(p));
        }
    }
}
