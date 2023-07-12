using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFeature()
        {
            ViewBag.featureTitle = _db.TblFeatures.Select(x => x.FeatureTitle).FirstOrDefault();
            ViewBag.featureDescription = _db.TblFeatures.Select(x => x.FeatureDescription).FirstOrDefault();
            ViewBag.featureImage = _db.TblFeatures.Select(x => x.FeatureImageURL).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.aboutTitle = _db.TblAbouts.Select(x => x.AboutTitle).FirstOrDefault();
            ViewBag.aboutShort = _db.TblAbouts.Select(x => x.AboutShort).FirstOrDefault();
            ViewBag.CvLink = _db.TblAbouts.Select(x => x.CvLink).FirstOrDefault();
            ViewBag.aboutImage = _db.TblAbouts.Select(x => x.AboutImage).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialMyResume()
        {
            var values = _db.TblResumes.ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = _db.TblServices.ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialStatistics()
        {
            ViewBag.totalProject = _db.TblProjects.Count();
            ViewBag.totalMessage = _db.TblMessages.Count();
            ViewBag.totalThanksMessage = _db.TblMessages.Count(x => x.MessageSubject == "Teşekkür");
            ViewBag.happyCustomer = 5;
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialReference()
        {
            var values = _db.TblReferences.ToList();

            return PartialView(values);
        }
    }
}