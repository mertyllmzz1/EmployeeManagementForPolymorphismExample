using System;

namespace EmployeeManagementForPolymorphismExample
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeAnnualLeave employeeAnnual = new EmployeeAnnualLeave();
            EmployeeAnnualLeave employeeAnnual1 = new EmployeeAnnualLeave();
            employeeAnnual.name = "Mert";
            employeeAnnual.surname = "Yılmaz";
            employeeAnnual.IsSmooking = false;
            employeeAnnual.countWorkWeek = 110;
            Console.WriteLine(employeeAnnual.name + ' ' + employeeAnnual.surname + ' ' + employeeAnnual.EmployeeAnnualLeaveDays(15) + "gün izin hakkı kazanmıştır."); 
            employeeAnnual1.name = "Enes";
            employeeAnnual1.surname = "Aracı";
            employeeAnnual1.IsSmooking = true;
            employeeAnnual1.countWorkWeek = 110;
            Console.WriteLine(employeeAnnual1.name +' '+employeeAnnual1.surname+' '+ employeeAnnual1.EmployeeAnnualLeaveDays(15)+"gün izin hakkı kazanmıştır.");
        }
    }
    class EmployeeManagement
    {
        //Örneğimiz sigara içmeyen çalışanlarımıza yılda ek 5 gün izin verildiği bir kurgu olsun :)
        public string name, surname;
        public int countWorkWeek;
        private int _AnnualLeave;
        
        public int AnnualLeave { get { return _AnnualLeave; } set { _AnnualLeave = value; }}
        

        public virtual int EmployeeAnnualLeaveDays(int annualDay)
        {
            return (int)(countWorkWeek / 52) * annualDay;
        }
    }
    class EmployeeAnnualLeave : EmployeeManagement
    {
        private bool _IsSmooking;
        public bool IsSmooking { get { return _IsSmooking; } set { _IsSmooking = value; } }
        public override int EmployeeAnnualLeaveDays(int annualDay)
        {
            if (!IsSmooking)
            {
                annualDay +=  5;
            }
            return base.EmployeeAnnualLeaveDays(annualDay);
        }
    }
}
