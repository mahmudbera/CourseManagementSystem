using Entities.Model;
using Repositories.Contracts;

namespace Repositories
{
	public class ClassroomRepository : RepositoryBase<Classroom>, IClassroomRepository
	{
		public ClassroomRepository(RepositoryContext context) : base(context)
		{
		}
	}
}