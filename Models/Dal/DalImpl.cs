using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASPDotnetCoreMVC.Models{
    public class DallImpl : IDal
    {
         private DataBaseContext db;
         public DallImpl(DataBaseContext DBContext)
         {
             db=DBContext;
         }
        public List<Employee> AddEmployee(Employee employee)
        {
         db.Employees.Add(employee);
         db.SaveChanges(); 
         return db.Employees.ToList();
        }

        public List<Company> CreationCompany(Company company)
        {
            db.Companies.Add(company);
            db.SaveChanges();
            return db.Companies.ToList();
            
        }

        public List<Company> DeletCompany(int Id)
        {
          Company company=db.Companies.Find(Id);
           if(company != null)
           {
               db.Companies.Attach(company);
               db.Companies.Remove(company);
               db.SaveChanges();
           }
           return db.Companies.ToList();

           }
            
        

        public List<Employee> DeletEmployee(int Id)
        {
            Employee employee=db.Employees.Find(Id);
           if(employee != null)
           {
               db.Employees.Attach(employee);
               db.Employees.Remove(employee);
               db.SaveChanges();
           }
           return db.Employees.ToList();

            
        }

        public List<Company> GetAllCompany()
        {
           return db.Companies.ToList();
            
        }

        public List<Employee> GetAllEmployee()
        {
         return db.Employees.Include(employee => employee.company).ToList();   
        }

        public List<Company> UpdateCompany(Company company)
        {
            Company _company= db.Companies.FirstOrDefault(o => o.CompanyId== company.CompanyId);
                _company.Name = company.Name;
                _company.Adress = company.Adress;
                db.SaveChanges();
            return db.Companies.ToList();
            
        }

        public List<Employee> UpdateEmployee(Employee employee)
        {
         Employee _employee= db.Employees.FirstOrDefault(e => e.EmployeeId==employee.EmployeeId);
         _employee.Name = employee.Name ;
         _employee.Surname = employee.Surname ;
         _employee.Adress = employee.Adress ;
         _employee.Gender = employee.Gender ;
         _employee.Email = employee.Email ;
         _employee.CompanyId = employee.CompanyId ;
         db.SaveChanges();
         return db.Employees.ToList();
            
        }
    }
}