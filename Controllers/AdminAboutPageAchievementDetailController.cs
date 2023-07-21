using Casgem_Portfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    [Authorize]
    public class AdminAboutPageAchievementDetailController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();

        public ActionResult Index()
        {
            ViewBag.countAchievement = _db.TblAchievementDetails.Count();
            var values = _db.TblAchievementDetails.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddAchievement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAchievement(TblAchievementDetail tblAchievement)
        {
            _db.TblAchievementDetails.Add(tblAchievement);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteAchievement(int id)
        {
            var value = _db.TblAchievementDetails.Find(id);
            _db.TblAchievementDetails.Remove(value);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAchievement(int id)
        {
            var value = _db.TblAchievementDetails.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAchievement(TblAchievementDetail tblAchievement)
        {
            var value = _db.TblAchievementDetails.Find(tblAchievement.Id);
            value.SmallTitle = tblAchievement.SmallTitle;
            value.Title = tblAchievement.Title;
            value.Skill1Title = tblAchievement.Skill1Title;
            value.Skill1Description = tblAchievement.Skill1Description;
            value.Skill2Title = tblAchievement.Skill2Title;
            value.Skill2Description = tblAchievement.Skill2Description;
            value.Skill3Title = tblAchievement.Skill3Title;
            value.Skill3Description = tblAchievement.Skill3Description;
            value.Skill4Title = tblAchievement.Skill4Title;
            value.Skill4Description = tblAchievement.Skill4Description;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}