using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.phoneNumber = _db.TblContacts.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.email = _db.TblContacts.Select(x => x.Email).FirstOrDefault();
            ViewBag.location = _db.TblContacts.Select(x => x.Location).FirstOrDefault();

            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMessage tblMessage)
        {
            
            if (ModelState.IsValid)
            {
                _db.TblMessages.Add(tblMessage);
                _db.SaveChanges();
                Thread.Sleep(500);

                return RedirectToAction("Index", "Portfolio");
                // return Json(new { success = true });
            }

            return View(tblMessage);
        }
    }
}