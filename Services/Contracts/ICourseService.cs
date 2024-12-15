using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
	public interface ICourseService
	{
		int GetActiveCoursesCount();
		IQueryable<Course> GetAllCourses(bool trackChanges);
		IQueryable<Course> GetAvailableCourses(int id);
		IQueryable<Course> GetAvailableCoursesForNewClassroom();
		Course GetCourseById(int id, bool trackChanges);
		(bool isSuccess, string message) CreateCourse(Course course);
		(bool isSuccess, string message) UpdateOneCourse(CourseDtoForUpdate courseDto);
		(bool Success, string Message) DeleteCourse(int courseId);
	}
}