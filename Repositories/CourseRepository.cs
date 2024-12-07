using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
	public class CourseRepository : RepositoryBase<Course>, ICourseRepository
	{
		public CourseRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}

        public void AddCourse(Course course)
        {
            Create(course);
        }

        public IQueryable<Course> GetAllCourses(bool trackChanges)
        {
            return FindAll(trackChanges);
        }
        
        
    }
}