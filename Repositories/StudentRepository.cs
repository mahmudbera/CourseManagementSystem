using Entities.Model;
using Repositories.Contracts;

namespace Repositories
{
	public class StudentRepository : RepositoryBase<Student>, IStudentRepository
	{
		public StudentRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}
	}
}