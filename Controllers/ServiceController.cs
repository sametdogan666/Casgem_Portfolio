using System.Linq;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();


        public ActionResult Index()
        {
            var values = db.TblServices.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(TblService tblService)
        {
            db.TblServices.Add(tblService);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var value = db.TblServices.Find(id);
            db.TblServices.Remove(value);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.TblServices.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService tblService)
        {
            var value = db.TblServices.Find(tblService.ServiceID);
            value.ServiceTitle = tblService.ServiceTitle;
            value.ServiceIcon = tblService.ServiceIcon;
            value.ServiceNumber = tblService.ServiceNumber;
            value.ServiceContent = tblService.ServiceContent;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}