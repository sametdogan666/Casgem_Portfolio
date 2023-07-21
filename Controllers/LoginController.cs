using System.Linq;
using Casgem_Portfolio.Models.Entities;
using System.Web.Mvc;
using System.Web.Security;

namespace Casgem_Portfolio.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
           
            var value = _db.TblAdmins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["userPortfolio"] = value.UserName.ToString();
                return RedirectToAction("Index", "AdminFeature");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Clear();

            return RedirectToAction("Index");
        }
    }
}