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

        public void CreateCourse(Course course) => Create(course);

        public IQueryable<Course> GetAllCourses(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public Course GetCourseById(int id, bool trackChanges)
        {
            return FindByCondition(c => c.CourseId.Equals(id), trackChanges)
                    .SingleOrDefault();
        }

        public void UpdateOneCourse(Course course) => Update(course);
    }
}