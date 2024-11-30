using Entities.Model;
using Repositories.Contracts;

namespace Repositories
{
	public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
	{
		public EnrollmentRepository(RepositoryContext context)
			: base(context)
		{
		}
	}
}