using System.Collections.Generic;
using Casgem_Portfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialAbout()
        {
            List<TblAboutDetail> details = new List<TblAboutDetail>();
            details = _db.TblAboutDetails.ToList();
            ViewBag.Detail= details.ToList();


            return PartialView(details);
        }

        public PartialViewResult PartialAboutSecond()
        {
            List<TblAboutDetailSecond> details = new List<TblAboutDetailSecond>();
            details = _db.TblAboutDetailSeconds.ToList();
            ViewBag.Detail = details.ToList();

            return PartialView(details);
        }

        public PartialViewResult PartialAchievementShort()
        {
            List<TblAchievement> details = new List<TblAchievement>();
            details = _db.TblAchievements.ToList();
            ViewBag.Detail = details.ToList();

            return PartialView(details);
        }

        public PartialViewResult PartialAchievement()
        {
            List<TblAchievementDetail> details = new List<TblAchievementDetail>();
            details = _db.TblAchievementDetails.ToList();
            ViewBag.Detail = details.ToList();

            return PartialView(details);
        }
    }
}