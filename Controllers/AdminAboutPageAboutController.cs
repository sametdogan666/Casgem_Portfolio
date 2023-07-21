using System.Linq;
using Casgem_Portfolio.Models.Entities;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    [Authorize]
    public class AdminAboutPageAboutController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            ViewBag.countAbout = _db.TblAboutDetails.Count();
            var values = _db.TblAboutDetails.ToList();

            return View(values);

        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(TblAboutDetail tblAboutDetail)
        {
            _db.TblAboutDetails.Add(tblAboutDetail);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = _db.TblAboutDetails.Find(id);
            _db.TblAboutDetails.Remove(value);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = _db.TblAboutDetails.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAboutDetail tblAboutDetail)
        {
            var value = _db.TblAboutDetails.Find(tblAboutDetail.Id);
            value.SmallTitle = tblAboutDetail.SmallTitle;
            value.Title = tblAboutDetail.Title;
            value.Description = tblAboutDetail.Description;
            value.Name = tblAboutDetail.Name;
            value.Age = tblAboutDetail.Age;
            value.City = tblAboutDetail.City;
            value.Email = tblAboutDetail.Email;
            value.ImageUrl = tblAboutDetail.ImageUrl;
            value.GithubUrl = tblAboutDetail.GithubUrl;
            value.InstagramUrl = tblAboutDetail.InstagramUrl;
            value.LinkedinUrl = tblAboutDetail.LinkedinUrl;
            value.City = tblAboutDetail.CvUrl;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}