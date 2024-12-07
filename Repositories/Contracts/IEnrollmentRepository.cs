using Entities.Models;

namespace Repositories.Contracts
{
	public interface IEnrollmentRepository : IRepositoryBase<Enrollment>
	{
		void CreateEnrollment(Enrollment enrollment);
	}
}