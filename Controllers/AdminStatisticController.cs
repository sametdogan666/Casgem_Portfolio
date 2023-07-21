using System.Linq;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    [Authorize]
    public class AdminStatisticController : Controller
    {
        private readonly CasgemPortfolioEntities1 _db = new CasgemPortfolioEntities1();
        public ActionResult Index()
        {
            ViewBag.employeeCount = _db.TblEmployees.Count();

            var salary = _db.TblEmployees.Max(x => x.EmployeeSalary);
            ViewBag.maxSalaryEmployee = _db.TblEmployees.Where(x => x.EmployeeSalary == salary)
                .Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();

            ViewBag.totalCityCount = _db.TblEmployees.Select(x => x.EmployeeCity).Distinct().Count();

            ViewBag.avgEmployeeSalary = _db.TblEmployees.Average(x => x.EmployeeSalary);


            ViewBag.countSoftwareDepartment = _db.TblEmployees.
                Count(x => x.EmployeeDepartment == _db.TblDepartments.
                    Where(z => z.DepartmentName == "Yazılım").
                Select(y => y.DepartmentID).FirstOrDefault());

            ViewBag.cityAnkaraOrAdanaSumSalary = _db.TblEmployees
                .Where(x => x.EmployeeCity == "Ankara" || x.EmployeeCity == "Adana")
                .Sum(y => y.EmployeeSalary);

            ViewBag.sumSalaryFromSoftwareDepartment = _db.TblEmployees.Where(x =>
                    x.EmployeeCity == "Ankara" && x.EmployeeDepartment == _db.TblDepartments
                        .Where(z => z.DepartmentName == "Yazılım").Select(y => y.DepartmentID).FirstOrDefault())
                .Sum(w => w.EmployeeSalary);

            return View();
        }
    }
}
