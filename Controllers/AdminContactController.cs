using System.Linq;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    [Authorize]
    public class AdminContactController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            ViewBag.countContact = _db.TblContacts.Count();
            var values = _db.TblContacts.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(TblContact tblContact)
        {
            _db.TblContacts.Add(tblContact);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteContact(int id)
        {
            var value = _db.TblContacts.Find(id);
            _db.TblContacts.Remove(value);
            _db.SaveChanges();

            return RedirectToAction("Index");
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