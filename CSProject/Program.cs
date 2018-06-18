using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fr = new FileReader();
            List<Staff> myStaff = new List<Staff>();
            PaySlip ps;
            int month = 0, year = 0;

            while(year == 0)
            {
                Console.WriteLine("\nPlease enter the year(yyyy): ");

                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("\nInvalid year. Enter an integer that is greater than 0");
                }
            }

            while(month == 0)
            {
                Console.WriteLine("\nPlease enter the month(1-12): ");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());

                    if (month > 12 || month < 1)
                    {
                        Console.WriteLine("\nInvalid month. Enter an integer 1-12");
                        month = 0;
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("\nInvalid month. Enter an integer 1-12");
                }
            }

            myStaff = fr.ReadFile();
            for(int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine("Enter hours worked for {0}", myStaff[i].NameOfStaff);
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Invalid entry try again");
                    i--;
                }
            }

            ps = new PaySlip(month, year);
            Console.WriteLine(ps.ToString());

            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Console.Read();
        }
    }
}
