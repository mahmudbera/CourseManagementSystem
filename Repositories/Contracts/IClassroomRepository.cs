using Entities.Models;

namespace Repositories.Contracts
{
	public interface IClassroomRepository : IRepositoryBase<Classroom>
	{
		void AddClassroom(Classroom classroom);
		void RemoveClassroom(Classroom classroom);
	}
}