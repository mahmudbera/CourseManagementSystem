using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
	public interface IInstructorService
	{
		IQueryable<Instructor> GetAllInstructors(bool trackChanges);
		void UpdateOneInstructor(InstructorDtoForUpdate instructorDto);
		int GetTotalInstructorsCount();
		
		// Instructor GetInstructorById(int id, bool trackChanges);
		// void CreateInstructor(Instructor instructor);
		// void DeleteInstructor(Instructor instructor);
	}
}