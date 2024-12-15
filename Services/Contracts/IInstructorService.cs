using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
	public interface IInstructorService
	{
		IQueryable<Instructor> GetAllInstructors(bool trackChanges);
		int GetTotalInstructorsCount();
		(bool isSuccess, string message) CreateInstructor(Instructor instructor);
		(bool isSuccess, string message) DeleteInstructor(int instructorId);
		(bool isSuccess, string message) UpdateOneInstructor(InstructorDtoForUpdate instructorDto);
	}
}