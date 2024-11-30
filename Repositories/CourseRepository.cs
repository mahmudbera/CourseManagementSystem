using Entities.Model;
using Repositories.Contracts;

namespace Repositories
{
	public class CourseRepository : RepositoryBase<Course>, ICourseRepository
	{
		public CourseRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}
	}
}