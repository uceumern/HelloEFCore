using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uuf.PersonManagement.Logic;
using uuf.PersonManagement.Model;
using uuf.PersonManagement.Model.Contracts;

namespace uuf.PersonManagement.Ui.Web.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        Core core;

        public EmployeeController(IRepository repository)
        {
            core = new Core(repository);
        }

        // GET: EmployeesController
        public ActionResult Index()
        {
            return View(core.Repository.GetAll<Employee>());
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repository.GetById<Employee>(id));
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View(new Employee() { Name = "New Employee" });
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(core.Repository.GetById<Employee>(id));
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.Repository.GetById<Employee>(id));
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
