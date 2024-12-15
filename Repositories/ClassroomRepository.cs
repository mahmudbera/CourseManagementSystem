using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Classroom> GetAllClassrooms(bool trackChanges) => FindAll(trackChanges).Include(c => c.Course);

        public Classroom GetClassroomById(int id, bool trackChanges) => FindByCondition(c => c.ClassroomId.Equals(id), trackChanges).Include(c=> c.Course).ThenInclude(c => c.Instructor).SingleOrDefault();

        public void RemoveClassroom(Classroom classroom) => Remove(classroom);

        public void UpdateClassroom(Classroom classroom) => Update(classroom);
    }
}