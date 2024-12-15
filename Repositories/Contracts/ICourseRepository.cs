using Entities.Models;

namespace Repositories.Contracts
{
	public interface ICourseRepository : IRepositoryBase<Course>
	{
		IQueryable<Course> GetAllCourses(bool trackChanges);
		Course GetCourseById(int id, bool trackChanges);
		Course GetCourseByName(string name, bool trackChanges);
		void CreateCourse(Course course);
		void UpdateOneCourse(Course course);
	}
}