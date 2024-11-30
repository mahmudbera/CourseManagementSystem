using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
	public class ClassroomService : IClassroomService
	{
		private readonly IRepositoryManager _manager;

        public ClassroomService(IRepositoryManager manager)
        {
            _manager = manager;
        }
    }
}