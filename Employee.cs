using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Mongohosting.Model
{
	public class Employee
	{
		[Key]
		public int EmployeeId { get; set; }
		[Required]
		public string Name { get; set; }
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? _id { get; set; }
		public int Age { get; set; }
		public string Designation { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public int ContactNumber { get; set; }
		//[ConcurrencyCheck]
		//public List<Salary> SalaryList { get; set; }
		public Salary Salary { get; set; }

		//public EmpDetails EmpDetail { get; set; }
		//public Projects Project { get; set; }
	}
}
