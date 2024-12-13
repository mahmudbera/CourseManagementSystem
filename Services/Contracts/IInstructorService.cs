using Entities.Models;

namespace Services.Contracts
{
	public interface IInstructorService
	{
		IQueryable<Instructor> GetAllInstructors(bool trackChanges);
		
		// Instructor GetInstructorById(int id, bool trackChanges);
		// void CreateInstructor(Instructor instructor);
		// void UpdateInstructor(Instructor instructor);
		// void DeleteInstructor(Instructor instructor);
	}
}