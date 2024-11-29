namespace Entities.Model
{
	public class Classroom
	{
		public int ClassroomId { get; set; }
		public string ClassroomName { get; set; }
		public int Capacity { get; set; }
		public int? CourseId { get; set; } // Nullable if no course assigned

		// Navigation Property
		public Course Course { get; set; }
	}
}