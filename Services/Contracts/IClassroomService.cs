using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
	public interface IClassroomService
	{
		IQueryable<Classroom> GetAllClassrooms(bool trackChanges);
		
		Classroom GetClassroomById(int id, bool trackChanges);
		int GetActiveClassroomsCount();
		(bool isSuccess, string message) UpdateClassroom(ClassroomDtoForUpdate classroomDto);
		(bool isSuccess, string message) CreateClassroom(Classroom classroom);
		(bool Success, string Message) DeleteClassroomById(int id);
	}
}