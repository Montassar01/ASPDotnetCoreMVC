using System.Collections.Generic;

namespace ASPDotnetCoreMVC.Models {
    public class BusinessImpl : IBusiness
    {
         private readonly IDal _dal ;
         public BusinessImpl(IDal dal){
             _dal= dal;
         }
        public List<Employee> AddEmployee(Employee employee)
        {
           return _dal.AddEmployee(employee);
        }

        public List<Company> CreationCompany(Company company)
        {
          return _dal.CreationCompany(company);   
        }

        public List<Company> DeletCompany(int Id)
        {
            return _dal.DeletCompany(Id);
        }

        public List<Employee> DeletEmployee(int Id)
        {
            return _dal.DeletEmployee(Id);
        }

        public List<Company> GetAllCompany()
        {
            return _dal.GetAllCompany();
        }

        public List<Employee> GetAllEmployee()
        {
            return _dal.GetAllEmployee();
        }

        public List<Company> UpdateCompany(Company company)
        {
            return _dal.UpdateCompany(company);
        }

        public List<Employee> UpdateEmployee(Employee employee)
        {
            return _dal.UpdateEmployee(employee);
        }
    }
}