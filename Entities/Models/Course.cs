using System.Collections.Generic;
namespace Entities.Model
{

	public class Course
	{
		public int CourseId { get; set; }
		public string CourseName { get; set; }
		public string Description { get; set; }
		public int Credits { get; set; }
		public int? InstructorId { get; set; } // Nullable for optional instructor assignment

		// Navigation Properties
		public Instructor Instructor { get; set; }
		public ICollection<Enrollment> Enrollments { get; set; }
		public Classroom Classroom { get; set; }
	}

}