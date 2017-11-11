using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIMS1A.Models
{
    public class Adminv
    {
    }

    public class EmpInfo
    {
        public int pay_commission { get; set; }
        public int grade_pay_p6 { get; set; }
     
        public DateTime date_of_next_increment { get; set; }

        public int emp_id { get; set; }
        
        public string emp_name { get; set; }
        public string designation { get; set; }
        public int designation_id { get; set; }
        public int dept_id { get; set; }
        public int division_id { get; set; }
        public string dept_name { get; set; }
        public string category { get; set; }
        public DateTime date_of_birth { get; set; }
        public string date_of_superannuation { get; set; }
         public string date_of_joining { get; set; }
         public string division { get; set; }
         public string status_to_date { get; set; }
         public string basic { get; set; }
         public string increment1 { get; set; }
         public string stagnation1 { get; set; }
         public string increment2 { get; set; }
         public string stagnation2 { get; set; }
         public string currentPay { get; set; }
         public string personal_pay_allowance { get; set; }
        public string deputation_pay_allowance{get;set;}

        
        
    }

}