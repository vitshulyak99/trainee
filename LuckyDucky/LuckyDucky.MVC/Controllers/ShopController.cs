﻿
using LuckyDucky.MailService.Interfaces;
using LuckyDucky.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace LuckyDucky.MVC.Controllers
{
    public class ShopController : Controller
    {
        IMailService _mailService;

        public ShopController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var info = HttpContext.Session.GetString("ContactMeInfo");

            var contactMeInfo = info is null ? new ShopAPIModel() : JsonConvert.DeserializeObject<ShopAPIModel>(info); 

            return View(new ContactMeModel { ContactMeInfo = contactMeInfo });
        }

        [HttpPost]
        public IActionResult Index([Bind("Name", "Email", "Message")] ContactMeModel model)
        {
            if (!ModelState.IsValid)
            {
                Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Count}");
                model.ContactMeInfo = new ShopAPIModel();
                return View(model);
            }
            
            //Debug.WriteLine($" From {model.Name} {model.Email} { model.Message }");
            _mailService.SendPlainTextEmail(new string[] { model.Email }, "Contact Me from Shop", $"From {model.Name} {model.Email} { model.Message}");
            
            HttpContext.Session.SetString("ContactMeInfo", JsonConvert.SerializeObject(new ShopAPIModel
            { 
                UserName = model.Name,
                IsContactMeRequested = true 
            }));

            return Redirect("/Shop");
        }
    }
}