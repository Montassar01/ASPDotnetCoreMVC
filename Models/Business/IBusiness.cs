using System.Collections.Generic;

namespace ASPDotnetCoreMVC.Models {
    public interface IBusiness
    {
    List <Company> GetAllCompany() ;  
    List <Employee> GetAllEmployee() ;  
    List <Company> CreationCompany( Company company) ;
    List <Employee> AddEmployee(Employee employee);
    List <Company> DeletCompany(int Id) ; 
     List <Employee> DeletEmployee(int Id) ; 
     List <Company> UpdateCompany(Company company) ;
     List <Employee> UpdateEmployee(Employee employee) ;  


    }

}