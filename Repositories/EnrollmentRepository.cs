using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
	public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
	{
		public EnrollmentRepository(RepositoryContext context)
			: base(context)
		{
		}

        public void CreateEnrollment(Enrollment enrollment)
        {
            Create(enrollment);
        }
    }
}