using System;
namespace Entities.Model
{

	public class Enrollment
	{
		public int EnrollmentId { get; set; }
		public int StudentId { get; set; }
		public int CourseId { get; set; }
		public DateTime EnrollmentDate { get; set; }
		public decimal? Grade { get; set; } // Nullable for ungraded courses

		// Navigation Properties
		public Student Student { get; set; }
		public Course Course { get; set; }
	}

}