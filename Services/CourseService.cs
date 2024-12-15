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

        public int GetActiveCoursesCount()
        {
            var activeCoursesCount = _manager.Course.GetAllCourses(trackChanges: false)
                .Where(c => c.Status == "Active").Count();
            return activeCoursesCount;
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

        public (bool Success, string Message) DeleteCourse(int courseId)
        {
            var course = _manager.Course.GetCourseById(courseId, trackChanges: true);

            if (course == null)
            {
                return (false, "Course not found.");
            }
            
            if (course.Status != "Inactive")
            {
                return (false, "Only inactive courses can be deleted.");
            }

            // Eğer Enrollment yoksa doğrudan sil
            if (course.Enrollments == null || !course.Enrollments.Any())
            {
                _manager.Course.Remove(course);
                _manager.Save();
                return (true, "Course deleted successfully.");
            }

            // Tüm Enrollment'larda Grade verilmişse sil
            bool allEnrollmentsHaveGrades = course.Enrollments.All(e => e.Grade != null);

            if (allEnrollmentsHaveGrades)
            {
                _manager.Course.Remove(course);
                _manager.Save();
                return (true, "Course deleted successfully.");
            }

            // Hiçbir koşul sağlanmadıysa
            return (false, "Course cannot be deleted because it has enrollments without grades.");
        }
    }
}