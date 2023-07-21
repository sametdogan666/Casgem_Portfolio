using Casgem_Portfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    [Authorize]
    public class AdminAboutPageAchievementController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();

        public ActionResult Index()
        {
            ViewBag.countAchievement = _db.TblAchievements.Count();
            var values = _db.TblAchievements.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddAchievement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAchievement(TblAchievement tblAchievement)
        {
            _db.TblAchievements.Add(tblAchievement);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteAchievement(int id)
        {
            var value = _db.TblAchievements.Find(id);
            _db.TblAchievements.Remove(value);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAchievement(int id)
        {
            var value = _db.TblAchievements.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAchievement(TblAchievement tblAchievement)
        {
            var value = _db.TblAchievements.Find(tblAchievement.Id);
            value.Title = tblAchievement.Title;
            value.Description = tblAchievement.Description;
            value.Achievement1 = tblAchievement.Achievement1;
            value.Achievement2 = tblAchievement.Achievement2;
            value.Achievement3 = tblAchievement.Achievement3;
            value.Achievement4 = tblAchievement.Achievement4;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}