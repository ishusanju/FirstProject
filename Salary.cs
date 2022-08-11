using System.ComponentModel.DataAnnotations;

namespace Mongohosting.Model
{
    public class Salary
    {
        [Key]

        public int SalaryId { get; set; }

        public string Name { get; set; }
        public int EmployeeSalary { get; set; }
        //public Employee Employee { get; set; }
        //public int empID { get; set; }
    }
}
