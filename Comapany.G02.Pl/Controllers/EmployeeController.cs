using AutoMapper;
using Comapany.G02.Pl.ViewModel;
using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comapany.G02.Pl.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public IActionResult Index(string searchName)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(searchName))
            {
               employees = _employeeRepository.GetAll();
            }
            else
            {
             employees = _employeeRepository.GetEmployeeByName(searchName);
              
            }
            var MappedEmployee = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(MappedEmployee);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                var mappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                var count = _employeeRepository.Add(mappedEmployee);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(employeeVM);
        }
        [HttpGet]
        public IActionResult Details(int? _id)
        {
            if (_id is null) return BadRequest();
            var employee = _employeeRepository.Get(_id.Value);
            var MappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(MappedEmployee);
        }
        [HttpGet]
        public IActionResult Edit(int? _id)
        {
            if (_id is null) return BadRequest();
            var employee = _employeeRepository.Get(_id.Value);
            return View(employee);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try

                {
                    var MappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employeeVM);
                    var count = _employeeRepository.Update(MappedEmployee);
                    if (count > 0)
                    {

                        return RedirectToAction("Index");
                    }
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                return View(employeeVM);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? _id)
        {
            if (_id is null) return BadRequest();
            var employee = _employeeRepository.Get(_id.Value);
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? id, EmployeeViewModel employeeVM)
        {
            try
            {
                if (id != employeeVM.Id) return BadRequest();
                if (ModelState.IsValid)
                {
                    var MappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employeeVM);
                    var count = _employeeRepository.Delete(MappedEmployee);
                    if (count > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(employeeVM);
        }
    }
}


