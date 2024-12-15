using Entities.Models;

namespace Repositories.Contracts
{
	public interface IClassroomRepository : IRepositoryBase<Classroom>
	{
		IQueryable<Classroom> GetAllClassrooms(bool trackChanges);
		Classroom GetClassroomById(int id, bool trackChanges);
		void AddClassroom(Classroom classroom);
		void RemoveClassroom(Classroom classroom);
		void UpdateClassroom(Classroom classroom);
	}
}