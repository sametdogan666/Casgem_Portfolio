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