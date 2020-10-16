using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckyDucky.MVC.Models
{
    public class ShopAPIModel
    {
        public string UserName { get; set; }

        public bool IsContactMeRequested { get; set; } = false;
    }
}
