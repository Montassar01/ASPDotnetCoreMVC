using System.Collections.Generic;
using System.Linq;
using ASPDotnetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotnetCoreMVC.Controllers
{
    public class EmployeeController : Controller
    {
    private readonly IBusiness _business ;
    public EmployeeController(IBusiness business){
        _business = business ;
    }


    public IActionResult Index(int page=0,int size=2){
        int position= page * size;
        List <Employee> employees = _business.GetAllEmployee().ToList();
        int total= employees.Count();
        employees= employees.OrderByDescending(c => c.CompanyId).Skip(position).Take(size).ToList();
        ViewBag.currentPage = page;
        int totalPages = total / size;
        if(total % size == 0)
        ViewBag.totalPages = totalPages ;
        else
        ViewBag.totalPages = totalPages +1 ;
        return View(employees);
    }

        public IActionResult Search(string keyWord,int page=0,int size=2){
        int position= page * size;
        int total=0;
        List <Employee> employees= new List<Employee> ();
        if(keyWord != null){
        employees = _business.GetAllEmployee().Where(c => c.EmployeeId.ToString().ToLower().Contains(keyWord.ToLower()) || c.Adress.ToLower().ToString().ToLower().Contains(keyWord.ToLower()) || c.Name.ToLower().ToString().ToLower().Contains(keyWord.ToLower()) || c.Gender.ToLower().ToString().ToLower().Contains(keyWord.ToLower()) || c.Surname.ToLower().ToString().ToLower().Contains(keyWord.ToLower()) || c.Email.ToLower().ToString().ToLower().Contains(keyWord.ToLower()) || c.company.Name.ToLower().ToString().ToLower().Contains(keyWord.ToLower()) ).ToList();
        total= employees.Count();
        employees= employees.OrderByDescending(c => c.CompanyId).Skip(position).Take(size).ToList();

        }
        else
        {
         employees = _business.GetAllEmployee().ToList();
        total= employees.Count();
        employees= employees.OrderByDescending(c => c.CompanyId).Skip(position).Take(size).ToList();

        }
        ViewBag.currentPage = page;
        int totalPages = total / size;
        if(total % size == 0)
        ViewBag.totalPages = totalPages ;
        else
        ViewBag.totalPages = totalPages +1 ;
        return View("Index",employees);
    }
      [HttpGet]
    public IActionResult Delete(int Id)
    {
        _business.DeletEmployee(Id);
        return RedirectToAction("Index");
    }

        public IActionResult AddOrUpdate (int Id=0)
     {
         Employee employee = new Employee () ;
         if(Id != 0)
         employee = _business.GetAllEmployee().FirstOrDefault(e =>e.EmployeeId == Id);
        return View(employee);
     }
     [HttpPost]
     public IActionResult save(Employee employee)
     {
     if(ModelState.IsValid)
     {
       if(employee.EmployeeId == 0)
             {
             _business.AddEmployee(employee); 
             }else{
             _business.UpdateEmployee(employee);
             }
         
        return RedirectToAction("Index");
     }
     ViewBag.Companies = _business.GetAllCompany();
     return View("AddOrUpdate");

     }
    
    }
}