using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
	public class StudentService : IStudentService
	{
		private readonly IRepositoryManager _manager;

        public StudentService(IRepositoryManager manager)
        {
            _manager = manager;
        }
    }
}