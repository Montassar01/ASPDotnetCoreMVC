using System.Collections.Generic;
using System.Linq;
using ASPDotnetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotnetCoreMVC.Controllers
{
    public class CompanyController : Controller
    {
    private readonly IBusiness _business ;
    public CompanyController(IBusiness business){
        _business = business ;
    }
    public IActionResult Index(int page=0,int size=2){
        int position= page * size;
        List <Company> companies = _business.GetAllCompany().ToList();
        int total= companies.Count();
        companies= companies.OrderByDescending(c => c.CompanyId).Skip(position).Take(size).ToList();
        ViewBag.currentPage = page;
        int totalPages = total / size;
        if(total % size == 0)
        ViewBag.totalPages = totalPages ;
        else
        ViewBag.totalPages = totalPages +1 ;
        return View(companies);
    }

    public IActionResult Search(string keyWord,int page=0,int size=2){
        int position= page * size;
        int total=0;
        List <Company> companies= new List<Company> ();
        if(keyWord != null){
        companies = _business.GetAllCompany().Where(c => c.CompanyId.ToString().ToLower().Contains(keyWord.ToLower()) || c.Adress.ToLower().ToString().ToLower().Contains(keyWord.ToLower()) || c.Name.ToLower().ToString().ToLower().Contains(keyWord.ToLower()) ).ToList();
        total= companies.Count();
        companies= companies.OrderByDescending(c => c.CompanyId).Skip(position).Take(size).ToList();

        }
        else
        {
         companies = _business.GetAllCompany().ToList();
        total= companies.Count();
        companies= companies.OrderByDescending(c => c.CompanyId).Skip(position).Take(size).ToList();

        }
        ViewBag.currentPage = page;
        int totalPages = total / size;
        if(total % size == 0)
        ViewBag.totalPages = totalPages ;
        else
        ViewBag.totalPages = totalPages +1 ;
        return View("Index",companies);
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        _business.DeletCompany(id);
        return RedirectToAction("Index");
    }
     public IActionResult AddOrUpdate (int Id=0)
     {
         Company company = new Company () ;
         if(Id != 0)
         company = _business.GetAllCompany().FirstOrDefault(c =>c.CompanyId == Id);
        return View(company);
     }
     [HttpPost]
     public IActionResult save(Company company)
     {
     if(ModelState.IsValid)
     {
        if(company.CompanyId == 0)
             {
             _business.CreationCompany(company); 
             }
             else
             {
             _business.UpdateCompany(company);
             }
         
        return RedirectToAction("Index");
     }
     return View("AddOrUpdate");

     }


    
    
    }
}