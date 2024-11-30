using Repositories.Contracts;

namespace Services.Contracts
{
	public class EnrollmentService : IEnrollmentService
	{
		private readonly IRepositoryManager _manager;

        public EnrollmentService(IRepositoryManager manager)
        {
            _manager = manager;
        }
    }
}