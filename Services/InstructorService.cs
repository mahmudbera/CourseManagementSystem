using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
	public class InstructorService : IInstructorService
	{
		private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public InstructorService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IQueryable<Instructor> GetAllInstructors(bool trackChanges)
        {
            return _manager.Instructor.GetAllInstructors(trackChanges);
        }

        public void UpdateOneInstructor(InstructorDtoForUpdate instructorDto)
        {
            var entitiy = _mapper.Map<Instructor>(instructorDto);
            _manager.Instructor.UpdateOneInstructor(entitiy);
            _manager.Save();
        }
    }
}