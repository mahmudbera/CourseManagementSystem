using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Entities.Models
{

	public class Course
	{
		[Required(ErrorMessage = "Course Id is required")]
		public int CourseId { get; set; }

		[Required(ErrorMessage = "Course Name is required")]
		public string CourseName { get; set; }
		[Required(ErrorMessage = "Course Code is required")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Credits is required")]
		public int Credits { get; set; }

		[Required(ErrorMessage = "Instructor Id is required")]
		public int? InstructorId { get; set; } // Nullable for optional instructor assignment

		public string Status { get; set; } = "Active"; // Active or Deactive

		// Navigation Properties
		public Instructor Instructor { get; set; }
		public ICollection<Enrollment> Enrollments { get; set; }
		public Classroom Classroom { get; set; }
	}

}