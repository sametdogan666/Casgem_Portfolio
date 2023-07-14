using System.Linq;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            var values = _db.TblAbouts.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = _db.TblAbouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout tblAbout)
        {
            var value = _db.TblAbouts.Find(tblAbout.AboutID);
            value.AboutTitle = tblAbout.AboutTitle;
            value.AboutShort = tblAbout.AboutShort;
            value.CvLink = tblAbout.CvLink;
            value.AboutImage = tblAbout.AboutImage;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}