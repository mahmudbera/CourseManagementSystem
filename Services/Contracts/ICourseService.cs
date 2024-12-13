using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
	public interface ICourseService
	{
		IQueryable<Course> GetAllCourses(bool trackChanges);
		Course GetCourseById(int id, bool trackChanges);
		void CreateCourse(Course course);
		void UpdateOneCourse(CourseDtoForUpdate courseDto);
	}
}