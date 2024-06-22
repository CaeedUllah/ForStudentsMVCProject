using Microsoft.AspNetCore.Mvc;
using MyMvcProject.MvcProjectsModels.Models;
using MyMvcProject.Repositories;

namespace MyMvcProject.Controllers
{
    

    public class EmployeeController : Controller
    {
        private readonly IRepository<Employees> EmployeeRepository;
        IUnitOfWork UnitOfWork;
        public EmployeeController(IRepository<Employees> employeeRepository, IUnitOfWork unitOfWork)
        {
            EmployeeRepository = employeeRepository;
            UnitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Employees> EmployeeList = (List<Employees>)EmployeeRepository.GetAll();
            return View(EmployeeList);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();

        }
        [HttpPost]
        public IActionResult Create(Employees obj)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository.Add(obj);
                UnitOfWork.Save();
                return RedirectToAction("Index", "Employee");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Employees employeeFromDb = EmployeeRepository.Get(u => u.EmployeeId == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Employees employeeFromDb = EmployeeRepository.Get(u => u.EmployeeId == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            EmployeeRepository.Remove(employeeFromDb);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Employees employeeFromDb = EmployeeRepository.Get(u => u.EmployeeId == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Employees obj)
        {
            /*Employees employeeFromDb = EmployeeRepository.Get(u => u.EmployeeId == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);*/
            if (ModelState.IsValid)
            {
                EmployeeRepository.update(obj);
                UnitOfWork.Save();
                /*TempData["success"] = "Category Updated Successfully!";*/
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
