using System;
using System.Collections.Generic;

namespace Entities.Model
{
	public class Student
	{
		public int StudentId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime EnrollmentDate { get; set; }

		// Navigation Property
		public ICollection<Enrollment> Enrollments { get; set; }
	}

}