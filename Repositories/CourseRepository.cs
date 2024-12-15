using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Course> GetAllCourses(bool trackChanges) => FindAll(trackChanges).Include(c => c.Classroom).Include(c => c.Instructor);

        public Course GetCourseById(int id, bool trackChanges)
        {
            return FindByCondition(c => c.CourseId.Equals(id), trackChanges)
                    .Include(c => c.Classroom)
                    .Include(c => c.Instructor)
                    .Include(c => c.Enrollments)
                    .ThenInclude(e => e.Student)
                    .SingleOrDefault();
        }

        public void UpdateOneCourse(Course course) => Update(course);
    }
}