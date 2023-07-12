using System.Linq;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            var values = _db.TblContacts.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = _db.TblContacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact tblContact)
        {
            var value = _db.TblContacts.Find(tblContact.ContactID);
            value.PhoneNumber = tblContact.PhoneNumber;
            value.Email = tblContact.Email;
            value.Location = tblContact.Location;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}