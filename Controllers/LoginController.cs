﻿using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int y)
        {
            return View();
        }
    }
}