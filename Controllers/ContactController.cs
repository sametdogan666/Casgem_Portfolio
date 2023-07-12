using System.Linq;
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
            _db.TblMessages.Add(tblMessage);
            _db.SaveChanges();

            return RedirectToAction("Index", "Portfolio");
        }
    }
}