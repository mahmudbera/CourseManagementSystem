using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;

namespace Services.Contracts
{
	public class CourseService : ICourseService
	{
		private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CourseService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateCourse(Course course)
        {
            _manager.Course.CreateCourse(course);
            _manager.Save();
        }

        public IQueryable<Course> GetAllCourses(bool trackChanges)
        {
            return _manager.Course.GetAllCourses(trackChanges);
        }

        public Course GetCourseById(int id, bool trackChanges)
        {
            return _manager.Course.GetCourseById(id, trackChanges);
        }

        public void UpdateOneCourse(CourseDtoForUpdate courseDto)
        {
            var entity = _mapper.Map<Course>(courseDto);
            _manager.Course.UpdateOneCourse(entity);
            _manager.Save();
        }
    }
}