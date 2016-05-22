using System.Net;
using System.Web.Mvc;
using HRManagement.DataAccess;
using HRManagement.DataAccess.Models.Models;
using HRManagement.Application;
using HRManagement.ViewModels.Employee;

namespace HRManagement.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;
        public HrContext db = new HrContext();
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: Employees
        public ActionResult Index()
        {
            var model = _employeeService.GetAllEmployees();
            return View(model);
        }

        // GET: Employees/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            var model = _employeeService.GetEmployeeForCreate();
            return View(model);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployeeViewModel input)
        {
            _employeeService.CreateEmployee(input);
            return RedirectToAction("Index");
           
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _employeeService.GetEmployeeForEdit(id);
            
            return View(model);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditEmployeeViewModel input)
        {
            _employeeService.SetChangesForEmployee(input.Id, input.PositionId, input.ProjectId, input.LastName, input.MiddleName, input.FirstName);

            return RedirectToAction("Index");
        }

        //GET: Employee/5/Trainings
        [HttpGet]
        [Route("employees/{employeeId}/trainings")]
        public ActionResult GetTrainingsForEmployee(int employeeId)
        {
            var model = _employeeService.GetTrainingForEmployee(employeeId);

            return View(model);
        }

        //GET: Employee/5/ContactInformation

        [HttpGet]
        public ActionResult GetContactInformationForEmployee(int employeeId)
        {
            var model = _employeeService.GetContactInformationForEmployee(employeeId);
            return View(model);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
  
    }
}
