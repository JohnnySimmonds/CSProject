using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30.0f;
        public int OvertimeHourLimit{get; private set;}
        public float Overtime{get; private set;}

        public Admin(string name) : base(name, adminHourlyRate) {
            OvertimeHourLimit = 160;
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if(HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - OvertimeHourLimit);
                TotalPay += Overtime;
            }

        }

        public override string ToString()
        {
            return base.ToString() + "\nAdmin overtime rate: " + overtimeRate + "\nOvertime hour limit: "
                + OvertimeHourLimit + "\nOvertime money earned: " + Overtime + "\nAdmin hourly rate: "
                + adminHourlyRate + "\n";
        }
    }
}
