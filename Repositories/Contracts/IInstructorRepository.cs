using Entities.Models;

namespace Repositories.Contracts
{
	public interface IInstructorRepository : IRepositoryBase<Instructor>
	{
		IQueryable<Instructor> GetAllInstructors(bool trackChanges);
		void AddInstructor(Instructor instructor);
		void UpdateOneInstructor(Instructor instructor);
	}
}