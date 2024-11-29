using Repositories.Contracts;

namespace Repositories
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T>
	where T: class, new()
	{
		protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
    }
}