using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
	public interface IClassroomService
	{
		IQueryable<Classroom> GetAllClassrooms(bool trackChanges);
		Classroom GetClassroomById(int id, bool trackChanges);
		void CreateClassroom(Classroom classroom);
		void UpdateClassroom(ClassroomDtoForUpdate classroomDto);
	}
}