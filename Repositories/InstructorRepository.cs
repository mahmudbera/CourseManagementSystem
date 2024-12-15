using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
	public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
	{
		public InstructorRepository(RepositoryContext context) : base(context)
		{
		}

        public void AddInstructor(Instructor instructor)
        {
            Create(instructor);
        }

        public IQueryable<Instructor> GetAllInstructors(bool trackChanges) => FindAll(trackChanges).Include(i => i.Courses);

        public void UpdateOneInstructor(Instructor instructor) => Update(instructor);
	}
}