﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    [Authorize]
    public class AdminMessageController : Controller
    {
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            var values = db.TblMessages.ToList();

            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = db.TblMessages.Find(id);
            db.TblMessages.Remove(value);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}