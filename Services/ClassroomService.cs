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

        public int GetActiveClassroomsCount()
        {
            var activeClassroomsCount = _manager.Classroom.GetAllClassrooms(false).Count();
            return activeClassroomsCount;
        }

        public IQueryable<Classroom> GetAllClassrooms(bool trackChanges)
        {
            return _manager.Classroom.GetAllClassrooms(trackChanges);
        }

        public Classroom GetClassroomById(int id, bool trackChanges)
        {
            return _manager.Classroom.GetClassroomById(id, trackChanges);
        }

        public (bool isSuccess, string message) UpdateClassroom(ClassroomDtoForUpdate classroomDto)
        {
            var entity = _mapper.Map<Classroom>(classroomDto);
            _manager.Classroom.UpdateClassroom(entity);
            bool changes = _manager.Save();

            if (changes)
                return (true, "Classroom updated successfully.");
            else
                return (false, "No changes were made or an error occurred.");
        }

        public (bool isSuccess, string message) CreateClassroom(Classroom classroom)
        {
            _manager.Classroom.AddClassroom(classroom);

            bool result = _manager.Save();

            if (result)
                return (true, "Classroom successfully created.");
            else
                return (false, "An error occurred while creating classroom.");
        }

        public (bool Success, string Message) DeleteClassroomById(int id)
        {
            var classroom = GetClassroomById(id, false);

            if (classroom == null)
            {
                return (false, "Classroom not found.");
            }

            if (classroom.Course != null)
            {
                return (false, "Classroom is assigned to a course. Please unassign it first.");
            }

            _manager.Classroom.Remove(classroom);
            _manager.Save();
            return (true, "Classroom deleted successfully.");
        }
    }
}