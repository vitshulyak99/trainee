using System;
using System.Linq;
using Task_2.Users;
using Task_2.Users.Roles;
using Task_2.UserManagers;

namespace Task_2.UserInterface
{

    class UI
    {

        readonly private Random _random = new Random();
        private UserManager _manager;
        public UI(UserManager userManager)
        {
            _manager = userManager;
        }

        public void CommandExecute(string commandId)
        {

            switch (commandId)
            {

                case "0": _manager.SetDefaultList(); break;

                case "1":
                    {
                        _manager.Users.ForEach(u =>
                        Console.WriteLine(@"{0} {1} {2} {3} {4}",
                        u.Role, u.Name, u.NickName == null | u.NickName == string.Empty ? "" : $"({ u.NickName})",
                        u.Age, u.Balance)
                        );
                    }
                    break;

                case "2":
                    {
                        _manager.Users.Add(new BaseUser("Ivan Ivanov", 21, 0) { NickName = "Novice" });
                    }
                    break;

                case "3":
                    {
                        _manager.Users.ForEach(u => u.DoJob());
                    }
                    break;

                case "4":
                    {
                        _manager.Users.ForEach(u => u.AddToBalance(-2));
                    }
                    break;

                case "5":
                    {
                        _manager.Users.Where(u => u.Balance == 0).ToList().ForEach(i => Console.WriteLine(i.GetInfo()));
                    }
                    break;

                case "6":
                    {
                        var baseUsers = _manager.Users.Where(u => u.Role == UserRole.Base && u.Balance > 10).ToList();

                        if (baseUsers != null)
                        {
                            baseUsers.ForEach(b =>
                            {
                                var index = _manager.Users.IndexOf(b);
                                _manager.Users[index] = b.Upgrade();
                            });
                        }

                        var admins = _manager.Users.Where(u => u.Role == UserRole.Admin && u.Balance > 20).ToList();

                        if (admins != null)
                        {
                            admins.ForEach(a =>
                            {
                                var index = _manager.Users.IndexOf(a);
                                _manager.Users[index] = a.Upgrade();
                            });
                        }
                    }
                    break;

                case "7":
                    {
                        _manager.Users.RemoveAll(u => u.Role == UserRole.Secret && u.Balance > 30);
                    }
                    break;

                case "8":
                    {
                        var user = _manager.Users.FirstOrDefault(u => u.Role != UserRole.Secret);

                        if (user != null)
                            user.AddToBalance(-5);
                    }
                    break;

                case "9":
                    {
                        _manager.Users[_random.Next(0, _manager.Users.Count)].AddToBalance(10);
                    }
                    break;

            }
        }
    }
}

