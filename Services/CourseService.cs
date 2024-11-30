using Repositories.Contracts;

namespace Services.Contracts
{
	public class CourseService : ICourseService
	{
		private readonly IRepositoryManager _manager;

        public CourseService(IRepositoryManager manager)
        {
            _manager = manager;
        }
    }
}