using System.Linq;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    [Authorize]
    public class AdminAboutController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            ViewBag.countAbout = _db.TblAbouts.Count();
            var values = _db.TblAbouts.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(TblAbout tblAbout)
        {
            _db.TblAbouts.Add(tblAbout);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = _db.TblAbouts.Find(id);
            _db.TblAbouts.Remove(value);
            _db.SaveChanges();

            return RedirectToAction("Index");
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