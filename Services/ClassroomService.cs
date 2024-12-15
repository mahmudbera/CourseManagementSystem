using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
	public class ClassroomService : IClassroomService
	{
		private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ClassroomService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateClassroom(Classroom classroom)
        {
            _manager.Classroom.AddClassroom(classroom);
            _manager.Save();
        }

        public IQueryable<Classroom> GetAllClassrooms(bool trackChanges)
        {
            return _manager.Classroom.GetAllClassrooms(trackChanges);
        }

        public Classroom GetClassroomById(int id, bool trackChanges)
        {
            return _manager.Classroom.GetClassroomById(id, trackChanges);
        }

        public void UpdateClassroom(ClassroomDtoForUpdate classroomDto)
        {
            var entity = _mapper.Map<Classroom>(classroomDto);
            _manager.Classroom.UpdateClassroom(entity);
            _manager.Save();
        }
    }
}