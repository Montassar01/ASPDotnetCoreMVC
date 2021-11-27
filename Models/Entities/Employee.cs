using System.ComponentModel.DataAnnotations;

namespace ASPDotnetCoreMVC.Models
{
    
    public class Employee
    {
        public int EmployeeId {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Surname {get; set;}
        [Required]
 
        public string Gender {get; set;}
        [Required]

        public string Email {get; set;}
        [Required]

        public string Adress{get; set;}
        

        public string CompanyId{get; set;}
        

         public virtual Company company{get; set;}
    }
}