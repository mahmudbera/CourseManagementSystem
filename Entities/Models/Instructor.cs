using System;
using System.Collections.Generic;
namespace Entities.Model
{

	public class Instructor
	{
		public int InstructorId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public DateTime HireDate { get; set; }

		// Navigation Property
		public ICollection<Course> Courses { get; set; }
	}

}