using EmployeeProject.DBEntities;
using EmployeeProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeProject.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            this._employeeContext = employeeContext;
        }


        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            int employeeCount = _employeeContext.Set<Employee>().ToList().Count();
            
            var totalPages = employeeCount % pageSize == 0 || employeeCount< pageSize? (employeeCount / pageSize) 
                             : (employeeCount / pageSize) + 1;

            var currentPage = pageIndex != null ? (int)pageIndex : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages = totalPages;
            ViewBag.StartPage = startPage;
            ViewBag.EndPage = endPage;


            IEnumerable<EmployeeViewModel> model = _employeeContext.Set<Employee>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().OrderBy(x => x.Id).Select(s => new
            EmployeeViewModel
            {
                Id = s.Id,
                EmployeeTagNumber = s.EmployeeTagNumber,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                Department = s.Department,
                Age = s.Age,
                Designation = s.Designation
            }).ToList();

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();

                employee.Id = employeeViewModel.Id;
                employee.EmployeeTagNumber = employeeViewModel.EmployeeTagNumber;
                employee.FirstName = employeeViewModel.FirstName;
                employee.LastName = employeeViewModel.LastName;
                employee.Email = employeeViewModel.Email;
                employee.Department = employeeViewModel.Department;
                employee.Age = employeeViewModel.Age;
                employee.Designation = employeeViewModel.Designation;

                _employeeContext.Add(employee);
                _employeeContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            EmployeeViewModel model = new EmployeeViewModel();

            Employee employee = _employeeContext.Set<Employee>().SingleOrDefault(c => c.Id == id);
            if (employee != null)
            {
                model.Id = employee.Id;
                model.EmployeeTagNumber = employee.EmployeeTagNumber;
                model.FirstName = employee.FirstName;
                model.LastName = employee.LastName;
                model.Email = employee.Email;
                model.Department = employee.Department;
                model.Age = employee.Age;
                model.Designation = employee.Designation;
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employee = _employeeContext.Set<Employee>().SingleOrDefault(s => s.Id == employeeViewModel.Id);
                    if (employee != null)
                    {
                        employee.Id = employeeViewModel.Id;
                        employee.EmployeeTagNumber = employeeViewModel.EmployeeTagNumber;
                        employee.FirstName = employeeViewModel.FirstName;
                        employee.LastName = employeeViewModel.LastName;
                        employee.Email = employeeViewModel.Email;
                        employee.Department = employeeViewModel.Department;
                        employee.Age = employeeViewModel.Age;
                        employee.Designation = employeeViewModel.Designation;
                    }

                    _employeeContext.Update(employee);
                    _employeeContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Employee employee = _employeeContext.Set<Employee>().SingleOrDefault(c => c.Id == id);
            _employeeContext.Remove(employee);
            _employeeContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
