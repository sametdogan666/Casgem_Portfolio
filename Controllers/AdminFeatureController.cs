using System.Linq;
using Casgem_Portfolio.Models.Entities;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    [Authorize]
    public class AdminFeatureController : Controller
    {
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();

        public ActionResult Index()
        {
            ViewBag.countFeature = db.TblFeatures.Count();
            var values = db.TblFeatures.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(TblFeature tblFeature)
        {
            db.TblFeatures.Add(tblFeature);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeatures.Find(id);
            db.TblFeatures.Remove(value);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TblFeatures.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeature tblFeature)
        {
            var value = db.TblFeatures.Find(tblFeature.FeatureID);
            value.FeatureTitle = tblFeature.FeatureTitle;
            value.FeatureDescription = tblFeature.FeatureDescription;
            value.FeatureImageURL = tblFeature.FeatureImageURL;
            value.FeatureSkill1 = tblFeature.FeatureSkill1;
            value.FeatureSkill2 = tblFeature.FeatureSkill2;
            value.FeatureSkill3 = tblFeature.FeatureSkill3;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}