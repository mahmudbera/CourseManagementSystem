using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
	public class InstructorService : IInstructorService
	{
		private readonly IRepositoryManager _manager;

        public InstructorService(IRepositoryManager manager)
        {
            _manager = manager;
        }
    }
}