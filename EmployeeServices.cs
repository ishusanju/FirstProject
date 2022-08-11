using Mongohosting.Model;

using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Mongohosting.Services
{
    public class EmployeeServices
    {
        public IMongoCollection<Employee> _Employee;
        public EmployeeServices(IOptions<EmployeeDatabaseSettings> empdbsettingsmongo)
        {
           var client = new MongoClient(empdbsettingsmongo.Value.ConnectionString);
           var database = client.GetDatabase(empdbsettingsmongo.Value.DatabaseName);
           _Employee = database.GetCollection<Employee>(empdbsettingsmongo.Value.CollectionName);
        }
        public Employee Get(int id)
        {
            var employee = _Employee.Find(x => x.EmployeeId == id).First();
            if (employee == null)
                return null;
            return employee;

        }
        public void AddEmp(int ID, string Name, string Address)
        {
            Employee addemp = new Employee() { EmployeeId = ID, Name = Name, City = Address };
            _Employee.InsertOne(addemp);
        }
        public void Update(int ID, string Name)
        {
            Employee emp = _Employee.Find(x => x.EmployeeId == ID).First();
            emp.Name = Name;
            var updateemp = _Employee.ReplaceOne(x => x.EmployeeId == ID, emp);


        }
        public void Delete(int ID)
        {
            _Employee.DeleteOne(x => x.EmployeeId == ID);
        }
    }
}
