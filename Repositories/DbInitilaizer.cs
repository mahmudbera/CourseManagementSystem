using System;
using System.Collections.Generic;
using Entities.Model;

namespace Repositories
{
    public static class DbInitializer
    {
        public static void Initialize(RepositoryContext context)
        {
            // Check if the database is already populated
            if (context.Students.Any() || context.Courses.Any() || context.Instructors.Any() || context.Classrooms.Any())
            {
                return; // Database has been seeded
            }

            // Seed Instructors
            var instructors = new List<Instructor>
            {
                new Instructor { FirstName = "John", LastName = "Doe", Email = "johndoe@email.com", HireDate = DateTime.Now },
                new Instructor { FirstName = "Jane", LastName = "Smith", Email = "janesmith@email.com", HireDate = DateTime.Now }
            };
            context.Instructors.AddRange(instructors);

            // Seed Students
            var students = new List<Student>
            {
                new Student { FirstName = "Alice", LastName = "Johnson", Email = "alice@email.com", DateOfBirth = DateTime.Parse("2000-01-01"), EnrollmentDate = DateTime.Now },
                new Student { FirstName = "Bob", LastName = "Brown", Email = "bob@email.com", DateOfBirth = DateTime.Parse("2000-02-01"), EnrollmentDate = DateTime.Now }
            };
            context.Students.AddRange(students);

            // Seed Courses
            var courses = new List<Course>
            {
                new Course { CourseName = "Math 101", Description = "Basic Mathematics", Credits = 3, InstructorId = 1 },
                new Course { CourseName = "History 101", Description = "Basic History", Credits = 3, InstructorId = 2 }
            };
            context.Courses.AddRange(courses);

            // Seed Classrooms
            var classrooms = new List<Classroom>
            {
                new Classroom { ClassroomName = "Room A", Capacity = 30, CourseId = 1 },
                new Classroom { ClassroomName = "Room B", Capacity = 25, CourseId = 2 }
            };
            context.Classrooms.AddRange(classrooms);

            // Seed Enrollments
            var enrollments = new List<Enrollment>
            {
                new Enrollment { StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.Now },
                new Enrollment { StudentId = 2, CourseId = 2, EnrollmentDate = DateTime.Now }
            };
            context.Enrollments.AddRange(enrollments);

            // Save all changes
            context.SaveChanges();
        }
    }
}
