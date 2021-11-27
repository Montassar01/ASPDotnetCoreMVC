using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPDotnetCoreMVC.Models{
    public class Company
    {
        public int CompanyId{get; set;}
        [Required]

        public string Name {get; set;}
        [Required]

        public string Adress{get; set;}
        

        public virtual List <Employee> employees {get; set;}
    }
}