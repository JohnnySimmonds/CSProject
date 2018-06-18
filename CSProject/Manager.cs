using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Manager : Staff
    {
        private const float managerHourlyRate = 50.0f;
        private const int minHoursWorkedToGiveAllowance = 160;
        public int Allowance {get; private set;}

        public Manager(string name) : base(name, managerHourlyRate){}

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;

            if (HoursWorked > minHoursWorkedToGiveAllowance)
                TotalPay += Allowance;
        }
        public override string ToString()
        {
            return base.ToString() + "\nManager rate of: " + managerHourlyRate + "\nAllowance of: " + Allowance 
                + "\nMinimum hours to get allowance: " + minHoursWorkedToGiveAllowance + "\n";
        }
    }
}
