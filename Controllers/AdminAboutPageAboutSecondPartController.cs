using Casgem_Portfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    [Authorize]
    public class AdminAboutPageAboutSecondPartController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();

        public ActionResult Index()
        {
            ViewBag.countAbout = _db.TblAboutDetailSeconds.Count();
            var values = _db.TblAboutDetailSeconds.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(TblAboutDetailSecond tblAboutDetail)
        {
            _db.TblAboutDetailSeconds.Add(tblAboutDetail);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = _db.TblAboutDetailSeconds.Find(id);
            _db.TblAboutDetailSeconds.Remove(value);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = _db.TblAboutDetailSeconds.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAboutDetailSecond tblAboutDetail)
        {
            var value = _db.TblAboutDetailSeconds.Find(tblAboutDetail.Id);
            value.SmallTitle = tblAboutDetail.SmallTitle;
            value.Title = tblAboutDetail.Title;
            value.Description = tblAboutDetail.Description;
            value.Skill1Title = tblAboutDetail.Skill1Title;
            value.Skill1Description = tblAboutDetail.Skill1Description;
            value.Skill2Title = tblAboutDetail.Skill2Title;
            value.Skill2Description = tblAboutDetail.Skill2Description;
            value.Skill3Title = tblAboutDetail.Skill3Title;
            value.Skill3Description = tblAboutDetail.Skill3Description;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}