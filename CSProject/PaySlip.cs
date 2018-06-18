using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSProject
{
    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEPT, OCT, NOV, DEC
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;

        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            
            foreach(Staff m in myStaff)
            {
                path = m.NameOfStaff + ".txt";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("=======================");
                    sw.WriteLine("Name of Staff: {0}", m.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", m.HoursWorked);
                    sw.WriteLine();
                    sw.WriteLine("Basic Pay: {0:C}", m.BasicPay);
                    if ((m.GetType() == typeof(Manager)) && m.HoursWorked >= 10)
                        sw.WriteLine("Allowance: {0:C}", ((Manager)m).Allowance);
                    else if ((m.GetType() == typeof(Admin)))
                    {
                        if(m.HoursWorked > ((Admin)m).OvertimeHourLimit)
                        sw.WriteLine("Overtime Pay: {0:C}", ((Admin)m).Overtime);

                    }
                    sw.WriteLine();
                    sw.WriteLine("=======================");
                    sw.WriteLine("Total Pay: {0:C}", m.TotalPay);
                    sw.WriteLine("=======================");

                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            string path = "summary.txt";

            var employees =
                  from staff in myStaff
                  where staff.HoursWorked < 10
                  orderby staff.NameOfStaff ascending
                  select new {staff.NameOfStaff, staff.HoursWorked};

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours\n");
               
                foreach(var m in employees)
                {
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", m.NameOfStaff, m.HoursWorked);
                }
                sw.Close();
            }
        }

        public override string ToString()
        {
           return "Month: " + (MonthsOfYear)month +" (" + month + ")" + "\nYear: " + year;
        }

    }
}
