using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using EIMS1A.Models;
using EIMS1A.Controllers;
using EIMS1A.Admindb;


namespace EIMS1A.Admindb
{
    public class Dbservice
    {
        public string conn = ConfigurationManager.AppSettings["MSSQL"].ToString();

        public object GetEmployeeInfoByEmpid(EmpInfo b)
        {
            //SqlConnection con = new SqlConnection(conn);

            //SqlCommand cmd1 = new SqlCommand("sp_initial_new_gettingVehicleregNo", con);
            //cmd1.CommandType = CommandType.StoredProcedure;
            //cmd1.Parameters.Add(new SqlParameter("@empid",emp_id));
            //SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            //DataTable dt = new DataTable();
            //con.Open();
            //sda.Fill(dt);
            //return b;
            SqlConnection con1 = new SqlConnection(conn);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            cmd1.CommandText = @"select  h.pay_commission, h.grade_pay_p6,h.date_of_next_increment,
 b.emp_id,a.emp_name,c.designation,c.designation_id,d.dept_id,d.division_id,d.dept_name,a.category,
 a.date_of_birth,b.date_of_superannuation,a.date_of_joining,f.division,b.employee_status,
 b.status_to_date,g.basic,g.increment1,g.stagnation1,g.increment2,g.stagnation2,h.currentPay,
 h.personal_pay_allowance,h.deputation_pay_allowance from employee_master a,employee_transaction b,
 --VMaxEmpInfo e,
 designation_master c,dept_master d ,division_master f ,payscale_master g,payscale_transaction h
  where g.payscale_id=h.payscale_id and h.emp_id=a.emp_id and  f.div_id=d.division_id
   and 
   --b.transaction_id=e.transaction_id and 
    a.emp_id=b.emp_id and  b.emp_id=b.emp_id and
 b.emp_id=a.emp_id and b.designation_id=c.designation_id and d.dept_id=b.dept_id and
 b.transaction_id in(select MAX(transaction_id) from Employee_Transaction group by emp_id) and
    h.transaction_id in (select max(transaction_id) as transaction_id from payscale_transaction t 
    where t.emp_id=h.emp_id ) and  b.emp_id='" + b.emp_id + "'";
            con1.Open();
            cmd1.Connection = con1;
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
               // b.emp_id = (int)dr["emp_id"];
                b.emp_id = Convert.ToInt32(dr["emp_id"]);

                b.emp_name = dr["emp_name"].ToString();
                b.division = dr["division"].ToString();
               // b.status_to_date = dr["status"].ToString();
                b.designation =dr["designation"].ToString();
                b.dept_name = dr["dept_name"].ToString();
                b.category = dr["category"].ToString();
              //  b.date_of_birth = b.date_of_birth.Date.ToString("MM/dd/yyyy");
              //  b.currentPay = dr["payscale"].ToString();
             //   b.date_of_next_increment = b.date_of_next_increment.Date.ToString("MM/dd/yyyy");

               // b.currentPay = (int)dr["Registarationcharge"];
                //b.ConsultationCharge = (int)dr["ConsultationCharge"];
                //b.DressingCharge = (int)dr["DressingCharge"];
                //b.PlasteringCharge = (int)dr["DressingCharge"];
                //b.DressingCharge = (int)dr["PlasteringCharge"];
                //b.InjectionCharge = (int)dr["InjectionCharge"];
                //b.XRayCharge = (int)dr["XRayCharge"];
                //b.OtherCharge = (int)dr["OtherCharge"];
                //b.TotalCharge = (int)dr["TotalCharge"];
                //b.PaymentMode = dr["Paymentmode"].ToString();
                //b.TransactionID = dr["Transactionid"].ToString();

                //d.DOB = d.DOB.Date.ToString("MM/dd/yyyy");

            }
            con1.Close();

            return b;
        }

    }
}