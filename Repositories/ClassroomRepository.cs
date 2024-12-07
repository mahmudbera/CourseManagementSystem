using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
	public class ClassroomRepository : RepositoryBase<Classroom>, IClassroomRepository
	{
		public ClassroomRepository(RepositoryContext context) : base(context)
		{
		}

        public void AddClassroom(Classroom classroom)
        {
            Create(classroom);
        }

        public void RemoveClassroom(Classroom classroom)
        {
            throw new NotImplementedException();
        }
    }
}