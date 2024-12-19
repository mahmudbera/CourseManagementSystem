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

        public IQueryable<Course> GetAvailableCourses(int id)
        {
            var courses = _manager.Course.GetAllCourses(false);
            var availableCourses = courses.Where(c => (c.Classroom == null || c.Classroom.ClassroomId == id) && c.Status.Equals("Active"));
            return availableCourses;
        }
        public IQueryable<Course> GetAvailableCoursesForNewClassroom()
        {
            var courses = _manager.Course.GetAllCourses(false);
            var availableCourses = courses.Where(c => c.Classroom == null && c.Status.Equals("Active"));
            return availableCourses;
        }

        public Course GetCourseById(int id, bool trackChanges)
        {
            return _manager.Course.GetCourseById(id, trackChanges);
        }

        public (bool isSuccess, string message) UpdateOneCourse(CourseDtoForUpdate courseDto)
        {
            var entity = _mapper.Map<Course>(courseDto);

            var existingCourse = _manager.Course.GetAllCourses(false)
                .FirstOrDefault(c => c.CourseName == entity.CourseName && c.CourseId != entity.CourseId);

            if (existingCourse != null)
                return (false, "Another course with the same name already exists.");
                
            _manager.Course.UpdateOneCourse(entity);
            bool changes = _manager.Save();

            if (changes)
                return (true, "Course updated successfully.");
            else
                return (false, "No changes were made or an error occurred.");
        }

        public (bool isSuccess, string message) CreateCourse(Course course)
        {
            var existingCourse = _manager.Course.GetCourseByName(course.CourseName, false);
            if (existingCourse != null)
                return (false, "A course with this name already exists.");

            _manager.Course.CreateCourse(course);
            bool result = _manager.Save();
            if (result)
                return (true, "Course successfully created.");
            else
                return (false, "Failed to save the course.");
        }

        public (bool Success, string Message) DeleteCourse(int courseId)
        {
            var course = _manager.Course.GetCourseById(courseId, trackChanges: true);

            if (course == null)
                return (false, "Course not found.");

            if (course.Status != "Inactive")
                return (false, "Only inactive courses can be deleted.");

            if (course.Enrollments == null || !course.Enrollments.Any())
            {
                _manager.Course.Remove(course);
                _manager.Save();
                return (true, "Course deleted successfully.");
            }

            bool allEnrollmentsHaveGrades = course.Enrollments.All(e => e.Grade != null);

            if (allEnrollmentsHaveGrades)
            {
                _manager.Course.Remove(course);
                _manager.Save();
                return (true, "Course deleted successfully.");
            }

            return (false, "Course cannot be deleted because it has enrollments without grades.");
        }

    }
}