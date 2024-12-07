using Entities.Models;

namespace Repositories.Contracts
{
	public interface ICourseRepository : IRepositoryBase<Course>
	{
		IQueryable<Course> GetAllCourses(bool trackChanges);
		void AddCourse(Course course);
	}
}