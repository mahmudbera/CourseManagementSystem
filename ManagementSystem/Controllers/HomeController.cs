using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Models;
using Services.Contracts;

namespace ManagementSystem.Controllers;

public class HomeController : Controller
{
    private readonly IServiceManager _manager;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IServiceManager manager)
    {
        _logger = logger;
        _manager = manager;
    }

    public IActionResult Index()
    {
        int activeClassroomCount = _manager.ClassroomService.GetActiveClassroomsCount();
        int activeCourseCount = _manager.CourseService.GetActiveCoursesCount();
        int totalInstructorCount = _manager.InstructorService.GetTotalInstructorsCount();
        int activeStudentCount = _manager.StudentService.GetActiveStudentsCount();

        // Store the values in ViewBag
        ViewBag.ActiveStudents = activeStudentCount;
        ViewBag.ActiveCourses = activeCourseCount;
        ViewBag.ActiveClassrooms = activeClassroomCount;
        ViewBag.TotalInstructors = totalInstructorCount;

        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
