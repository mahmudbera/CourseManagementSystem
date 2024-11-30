using Entities.Model;
using Repositories.Contracts;

namespace Repositories
{
	public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
	{
		public InstructorRepository(RepositoryContext context) : base(context)
		{
		}
	}
}