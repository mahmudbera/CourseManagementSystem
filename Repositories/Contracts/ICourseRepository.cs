using Entities.Models;

namespace Repositories.Contracts
{
	public interface ICourseRepository : IRepositoryBase<Course>
	{
		IQueryable<Course> GetAllCourses(bool trackChanges);
		void CreateCourse(Course course);
		Course GetCourseById(int id, bool trackChanges);
		void UpdateOneCourse(Course course);
	}
}