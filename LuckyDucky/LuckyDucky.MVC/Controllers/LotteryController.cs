using LuckyDucky.Lottery.Interfaces;
using LuckyDucky.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;


namespace LuckyDucky.MVC.Controllers
{
    public class LotteryController : Controller
    {
        ILotteryService _lotteryService;

        string _keyCookie = ".AlwaysTakePart";


        CookieOptions coookieOptions = new CookieOptions() { Expires = DateTime.Now.AddDays(30), Secure = true, HttpOnly = true };
        public LotteryController(ILotteryService lotteryService)
        {
            _lotteryService = lotteryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            TakePartModel model = new TakePartModel();

            if (HttpContext.Request.Cookies.ContainsKey(_keyCookie))
            {

                var cookie = HttpContext.Request.Cookies[_keyCookie];
                model = JsonConvert.DeserializeObject<TakePartModel>(cookie);
                HttpContext.Response.Cookies.Append(_keyCookie, cookie, coookieOptions);

            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Index([Bind("Name", "Email", "IsAlwaysTakePartCheck")] TakePartModel model)
        {
            if (HttpContext.Request.Cookies.ContainsKey(_keyCookie))
            {
                //click "Do Not Take Part"

                model = JsonConvert.DeserializeObject<TakePartModel>(HttpContext.Request.Cookies[_keyCookie]);

                if (model.IsAlwaysTakePartCheck)
                {
                    HttpContext.Response.Cookies.Delete(_keyCookie);
                }

                return LocalRedirect("/Lottery/");
            }
            else
            {
                //click "Take Part"

                if (ModelState.IsValid)
                {
                    if (model.IsAlwaysTakePartCheck)
                    {
                        HttpContext.Response.Cookies.Append(_keyCookie, JsonConvert.SerializeObject(model), coookieOptions);
                    }

                    _lotteryService.SubscribeUser(model.Name, model.Email);

                    return View(model);
                }
                else
                {
                    model.IsAlwaysTakePartCheck = false;
                    return View(model);
                }
            }
        }

       
    }
}